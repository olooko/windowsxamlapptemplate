using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Graphics;
using WindowsXamlApp.Template.MAUI.Views.Pages;

namespace WindowsXamlApp.Template.MAUI
{
    public class LoadingOverlay : WindowOverlay
    {
        IWindowOverlayElement _loadingElementOverlay;

        public LoadingOverlay(IWindow window)
            : base(window)
        {
            this._loadingElementOverlay = new LoadingElementOverlay(this);
            AddWindowElement(_loadingElementOverlay);
        }


        class LoadingElementOverlay : IWindowOverlayElement
        {
            readonly IWindowOverlay _overlay;
            RectF _backgroundRect = new RectF();
            Color _backgroundColor = Color.FromArgb("FF000000");
            Color _loadingSpinnerColor = Colors.White;

            public LoadingElementOverlay(IWindowOverlay overlay, Color? background = null, Color? spinner = null)
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

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new MainWindow(Ioc.Default.GetRequiredService<IndexPage>());
            //window.SetMauiContext(this.MauiContext);
            
            return window;
        }
    }
}