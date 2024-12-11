using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WindowsXamlApp.Common.DialogModels;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WinUI.Extensions;
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

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();

            _host = builder.Build();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            if (_host != null)
            {
                var window = _host.Services.GetRequiredService<MainWindow>();
                var page = _host.Services.GetRequiredService<IndexPage>();
                window.FrameContent.Content = page;
                window.Activate();
            }
        }
    }
}
