using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WinUI.Views;

namespace WindowsXamlApp.Template.WinUI
{
    public partial class App : Application
    {
        protected readonly IHost? _host;

        public App()
        {
            this.InitializeComponent();

            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddSingleton(typeof(MainWindow));

            builder.Services.AddSingleton(typeof(MainView));

            builder.Services.AddSingleton(typeof(MainViewModel));

            _host = builder.Build();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            if (_host != null)
            {
                var window = _host.Services.GetRequiredService<MainWindow>();

                window.SetView(_host.Services.GetRequiredService<MainView>());
                window.Activate();
            }
        }
    }
}
