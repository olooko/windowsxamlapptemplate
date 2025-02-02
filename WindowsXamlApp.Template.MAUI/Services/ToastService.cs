using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public class ToastWindowOverlay : WindowOverlay
    {
        private IWindowOverlayElement _toastWindowOverlayElement;

        public ToastWindowOverlay(IWindow window) : base(window)
        {
            _toastWindowOverlayElement = new ToastWindowOverlayElement(this);
            AddWindowElement(_toastWindowOverlayElement);
        }

        class ToastWindowOverlayElement : IWindowOverlayElement
        {
            readonly IWindowOverlay _overlay;

            RectF _backgroundRect = new RectF();
            Color _backgroundColor = Color.FromArgb("FF000000");
            Color _loadingSpinnerColor = Colors.White;

            public ToastWindowOverlayElement(IWindowOverlay overlay, Color? background = null, Color? spinner = null)
            {
                _overlay = overlay;
                if (background != null)
                    this._backgroundColor = background;
                if (spinner != null)
                    _loadingSpinnerColor = spinner;
            }

            public bool Contains(Point point)
                => this._backgroundRect.Contains(new Point(point.X / _overlay.Density, point.Y / _overlay.Density));

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                this._backgroundRect = new RectF(0, 0, 200, 200); //dirtyRect;
                canvas.FillColor = _backgroundColor;
                canvas.StrokeColor = _loadingSpinnerColor;
                canvas.FontColor = _loadingSpinnerColor;
                canvas.FontSize = 45f;

                canvas.FillRectangle(this._backgroundRect);

                
                canvas.DrawString("Now Loading...", dirtyRect.Width / 2, dirtyRect.Height / 2, HorizontalAlignment.Center);
            }
        }

    }



    public sealed class ToastService : IToastService
    {
        public void Show(string message)
        {
            var window = App.Current!.Windows[0];
            window.AddOverlay(new ToastWindowOverlay(window));
        }
    }
}
