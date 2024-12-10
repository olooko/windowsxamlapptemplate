using Microsoft.Extensions.Logging;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.MAUI.Extensions;
using WindowsXamlApp.Template.MAUI.Services;
using WindowsXamlApp.Template.MAUI.Views;

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
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();

            builder.Services.AddTransient<IndexPage>();

            builder.Services.AddTransient<IndexPageViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();

            return builder.Build();
        }
    }
}
