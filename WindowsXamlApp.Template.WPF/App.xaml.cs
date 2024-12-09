using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WPF.Extensions;
using WindowsXamlApp.Template.WPF.Services;
using WindowsXamlApp.Template.WPF.Views;

namespace WindowsXamlApp.Template.WPF
{
    public partial class App : Application
    {
        protected readonly IHost? _host;

        public App()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton<MainWindow>();

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();

            builder.Services.AddTransient<IndexPage>();

            builder.Services.AddTransient<IndexPageViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();
            
            _host = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            if (_host != null)
            {
                var window = _host.Services.GetRequiredService<MainWindow>();
                var page = _host.Services.GetRequiredService<IndexPage>();
                window.FrameContent.Navigate(page);
                window.Show();
            }
        }
    }
}
