using Microsoft.Maui.Animations;
using Microsoft.Maui.Graphics.Text;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public class ToastWindowOverlay : WindowOverlay
    {
        private ToastWindowOverlayElement _toastWindowOverlayElement;

        public ToastWindowOverlay(IWindow window, string message) : base(window)
        {
            _toastWindowOverlayElement = new ToastWindowOverlayElement(message);

            //var alphaAnimation = new Animation(v => windowElement.Alpha = (float)v, 0, 1);

            AddWindowElement(_toastWindowOverlayElement);
            //alphaAnimation.Commit((IAnimatable)this, "alpha");

            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Elapsed += Timer_Elapsed;
            //timer.Interval = 100;
            //timer.Start();
        }

        //private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        //{

        //    _toastWindowOverlayElement.Alpha += 0.01f;
        //    //_toastWindowOverlayElement.GenericLerp

        //    if (_toastWindowOverlayElement.Alpha > 100f)
        //    {
        //        System.Timers.Timer timer = (System.Timers.Timer)sender!;
        //        timer.Stop();
        //    }
        //}

        private class ToastWindowOverlayElement : IWindowOverlayElement
        {
            private float _alpha = 1.0f;
            public float Alpha
            {
                get => _alpha;
                set => _alpha = value;
            }

            private string _message;

            public ToastWindowOverlayElement(string message)
            {
                _message = message;
            }

            public bool Contains(Point point)
                => true;

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                float fontSize = 18f;
                var font = new Microsoft.Maui.Graphics.Font("Arial");

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

    public sealed class ToastService : IToastService
    {
        public void Show(string message)
        {
            var window = App.Current!.Windows[0];
            window.AddOverlay(new ToastWindowOverlay(window, message));
        }
    }
}
