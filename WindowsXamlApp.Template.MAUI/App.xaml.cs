using CommunityToolkit.Mvvm.DependencyInjection;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Pages;

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
            return new Window(new AppShell());
        }
    }
}