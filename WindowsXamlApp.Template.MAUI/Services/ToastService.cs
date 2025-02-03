using Microsoft.Maui.Graphics.Text;
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
                var font = new Microsoft.Maui.Graphics.Font("Arial");
                canvas.Font = font;
                canvas.FontColor = _loadingSpinnerColor;
                canvas.FontSize = 18f;

                SizeF stringSize = canvas.GetStringSize("Now Loading...", font, 18f);

                this._backgroundRect = new RectF(dirtyRect.Width / 2, dirtyRect.Height / 2, stringSize.Width, stringSize.Height);// dirtyRect;
                canvas.FillColor = _backgroundColor;
                canvas.StrokeColor = Colors.Red;


                canvas.FillRectangle(_backgroundRect);

                canvas.DrawString("Now Loading...", dirtyRect.Width / 2, dirtyRect.Height / 2, stringSize.Width, stringSize.Height, HorizontalAlignment.Center, VerticalAlignment.Bottom);
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
