using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WinUI.Pages;

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

            builder.Services.AddSingleton(typeof(IndexPage));

            builder.Services.AddSingleton(typeof(IndexPageViewModel));

            _host = builder.Build();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            if (_host != null)
            {
                var window = _host.Services.GetRequiredService<MainWindow>();
                window.Content = _host.Services.GetRequiredService<IndexPage>();
                window.Activate();
            }
        }
    }
}
