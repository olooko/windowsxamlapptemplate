using CommunityToolkit.Mvvm.DependencyInjection;
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
            var indexPage = Ioc.Default.GetRequiredService<IndexPage>();
            return new MainWindow(indexPage);
        }
    }
}