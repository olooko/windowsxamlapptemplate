using Microsoft.Extensions.Logging;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.MAUI.Pages;
using WindowsXamlApp.Template.MAUI.Services;

namespace WindowsXamlApp.Template.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(typeof(IDialogService), typeof(DialogService));
            builder.Services.AddSingleton(typeof(IToastService), typeof(ToastService));

            builder.Services.AddTransient<IndexPageViewModel>();

            builder.Services.AddTransient<IndexPage>();

            return builder.Build();
        }
    }
}
