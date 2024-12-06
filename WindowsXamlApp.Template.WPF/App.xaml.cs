using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WPF.Pages;
using WindowsXamlApp.Template.WPF.Services;

namespace WindowsXamlApp.Template.WPF
{
    public partial class App : Application
    {
        protected readonly IHost? _host;

        public App()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton(typeof(IToastService), typeof(ToastService));

            builder.Services.AddSingleton(typeof(MainWindow));

            builder.Services.AddSingleton(typeof(IndexPage));

            builder.Services.AddSingleton(typeof(IndexPageViewModel));

            _host = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            if (_host != null)
            {
                var window = _host.Services.GetRequiredService<MainWindow>();
                window.Content = _host.Services.GetRequiredService<IndexPage>();
                window.Show();
            }
        }
    }
}
