using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WindowsXamlApp.Common.ViewModels.Dialogs;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Pages;
using WindowsXamlApp.Template.WinUI.Extensions;
using WindowsXamlApp.Template.WinUI.Services;
using WindowsXamlApp.Template.WinUI.Views.Dialogs;
using WindowsXamlApp.Template.WinUI.Views.Pages;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace WindowsXamlApp.Template.WinUI
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton<MainWindow>();

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();

            builder.Services.AddSingleton<IndexPage>();

            builder.Services.AddSingleton<IndexPageViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();

            IHost host = builder.Build();

            Ioc.Default.ConfigureServices(host.Services);
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            var page = Ioc.Default.GetRequiredService<IndexPage>();
            window.FrameContent.Content = page;
            window.Activate();
        }
    }
}
