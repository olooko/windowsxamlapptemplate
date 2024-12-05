using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WPF.Views;

namespace WindowsXamlApp.Template.WPF
{
    public partial class App : Application
    {
        protected readonly IHost? _host;

        public App()
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton(typeof(MainWindow));

            builder.Services.AddSingleton(typeof(MainView));

            builder.Services.AddSingleton(typeof(MainViewModel));

            _host = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            if (_host != null)
            {
                var window = _host.Services.GetRequiredService<MainWindow>();

                window.SetView(_host.Services.GetRequiredService<MainView>());
                window.Show();
            }
        }
    }
}
