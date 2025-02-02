using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Graphics;
using WindowsXamlApp.Template.MAUI.Views.Pages;

namespace WindowsXamlApp.Template.MAUI
{
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