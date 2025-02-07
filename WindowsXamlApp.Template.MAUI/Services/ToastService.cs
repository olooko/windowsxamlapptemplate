using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class ToastService : IToastService
    {
        public void Show(string message, long duration, double fontSize)
        {
            var window = App.Current!.Windows[0];
            window.AddOverlay(new ToastWindowOverlay(window, message, duration, fontSize));
        }

        private class ToastWindowOverlay : WindowOverlay
        {
            private ToastWindowOverlayElement _toastWindowOverlayElement;
            private int _totalElapsedCount;
            private int _currentElapsedCount;
            private bool _isReverse;

            public ToastWindowOverlay(IWindow window, string message, long duration, double fontSize) : base(window)
            {
                _toastWindowOverlayElement = new ToastWindowOverlayElement(message, fontSize);

                this.AddWindowElement(_toastWindowOverlayElement);

                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 10;

                _totalElapsedCount = (int)(duration / timer.Interval) / 2;
                _currentElapsedCount = 0;

                _isReverse = false;

                timer.Start();
            }

            private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
            {
                System.Timers.Timer timer = (System.Timers.Timer)sender!;

                if (App.Current!.Windows.Count > 0)
                {
                    var window = App.Current!.Windows[0];

                    window.Dispatcher.Dispatch(() => {

                        if (_isReverse == false)
                        {
                            _toastWindowOverlayElement.Alpha = (float)PowerEase((double)_currentElapsedCount++ / _totalElapsedCount, 10);

                            if (_currentElapsedCount >= _totalElapsedCount)
                            {
                                _isReverse = true;
                            }
                        }
                        else
                        {
                            _toastWindowOverlayElement.Alpha = (float)PowerEase((double)_currentElapsedCount-- / _totalElapsedCount, 10);

                            if (_currentElapsedCount <= 0)
                            {
                                timer.Stop();
                                window.RemoveOverlay(this);
                            }
                        }

                        this.Invalidate();
                    });
                }
            }

            private double PowerEase(double t, double power)
            {
                return 1 - Math.Pow(1 - t, power);
            }

            private class ToastWindowOverlayElement : IWindowOverlayElement
            {
                private float _alpha = 0.0f;
                public float Alpha
                {
                    get => _alpha;
                    set => _alpha = value;
                }

                private string _message;
                private double _fontSize;

                public ToastWindowOverlayElement(string message, double fontSize)
                {
                    _message = message;
                    _fontSize = fontSize;
                }

                public bool Contains(Point point)
                    => true;

                public void Draw(ICanvas canvas, RectF dirtyRect)
                {
                    float fontSize = (float)_fontSize;
                    var font = new Microsoft.Maui.Graphics.Font("OpenSansRegular");

                    canvas.Font = font;
                    canvas.FontSize = fontSize;
                    canvas.FontColor = Colors.White;
                    canvas.FillColor = Colors.Black;
                    canvas.Alpha = _alpha;

                    SizeF stringSize = canvas.GetStringSize(_message, font, fontSize);

                    float width = stringSize.Width * 1.2f;
                    float height = stringSize.Height * 2.0f;
                    float x = (dirtyRect.Width - width) / 2.0f;
                    float y = dirtyRect.Height - (height * 1.5f);

                    canvas.FillRoundedRectangle(x, y, width, height, 8);

                    canvas.DrawString(_message, x, y, width, height, HorizontalAlignment.Center, VerticalAlignment.Center);
                }
            }
        }
    }
}
