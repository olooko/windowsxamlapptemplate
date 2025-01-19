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
            return new MainWindow(Ioc.Default.GetRequiredService<IndexPage>());
        }
    }
}