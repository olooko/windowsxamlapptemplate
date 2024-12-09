using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WinUI.Services;
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

            builder.Services.AddSingleton<MainWindow>();

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();

            builder.Services.AddSingleton<IndexPage>();

            builder.Services.AddSingleton<IndexPageViewModel>();

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
