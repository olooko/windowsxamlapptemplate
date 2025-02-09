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
        public App()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton<MainWindow>();

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();
            builder.Services.AddSingleton<IToastService, ToastService>();
            builder.Services.AddSingleton<IPageService, PageService>();

            builder.Services.AddTransientPage<IndexPage, IndexPageViewModel>();
            builder.Services.AddTransientPage<OtherPage, OtherPageViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();
            
            IHost host = builder.Build();

            Ioc.Default.ConfigureServices(host.Services);
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            Ioc.Default.GetRequiredService<MainWindow>().Show();
            Ioc.Default.GetRequiredService<IPageService>().Navigate<IndexPageViewModel>();
        }
    }
}
