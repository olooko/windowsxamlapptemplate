using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Dialogs;
using WindowsXamlApp.Common.ViewModels.Pages;
using WindowsXamlApp.Template.WPF.Extensions;
using WindowsXamlApp.Template.WPF.Services;
using WindowsXamlApp.Template.WPF.Views.Dialogs;
using WindowsXamlApp.Template.WPF.Views.Pages;

namespace WindowsXamlApp.Template.WPF
{
    public partial class App : Application
    {
        //protected readonly IHost? _host;

        public App()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton<MainWindow>();

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();

            builder.Services.AddTransient<IndexPage>();

            builder.Services.AddTransient<IndexPageViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();
            
            IHost host = builder.Build();

            Ioc.Default.ConfigureServices(host.Services);
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            var window = Ioc.Default.GetRequiredService<MainWindow>();
            var page = Ioc.Default.GetRequiredService<IndexPage>();
            window.FrameContent.Navigate(page);
            window.Show();
        }
    }
}
