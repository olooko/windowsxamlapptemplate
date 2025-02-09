using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Logging;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Dialogs;
using WindowsXamlApp.Common.ViewModels.Pages;
using WindowsXamlApp.Template.MAUI.Extensions;
using WindowsXamlApp.Template.MAUI.Services;
using WindowsXamlApp.Template.MAUI.Views.Dialogs;
using WindowsXamlApp.Template.MAUI.Views.Pages;

namespace WindowsXamlApp.Template.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //builder.Services.AddSingleton<MainWindow>();

            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();
            builder.Services.AddSingleton<IToastService, ToastService>();
            builder.Services.AddSingleton<IPageService, PageService>();

            builder.Services.AddTransientPage<IndexPage, IndexPageViewModel>();
            builder.Services.AddTransientPage<OtherPage, OtherPageViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();

            var app = builder.Build();

            Ioc.Default.ConfigureServices(app.Services);

            return app;
        }
    }
}
