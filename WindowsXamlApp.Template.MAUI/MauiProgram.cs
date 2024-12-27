﻿using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Logging;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Contents;
using WindowsXamlApp.Common.ViewModels.Dialogs;
using WindowsXamlApp.Common.ViewModels.Pages;
using WindowsXamlApp.Template.MAUI.Extensions;
using WindowsXamlApp.Template.MAUI.Services;
using WindowsXamlApp.Template.MAUI.Views.Contents;
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
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton<IPickerService, PickerService>();
            builder.Services.AddSingleton<IToastService, ToastService>();

            builder.Services.AddTransient<IndexPage>();
            builder.Services.AddTransient<AlertsContent>();

            builder.Services.AddTransient<IndexPageViewModel>();
            builder.Services.AddTransient<AlertsContentViewModel>();

            builder.Services.AddTransientDialog<ContentDialog, ContentDialogViewModel>();

            var app = builder.Build();

            Ioc.Default.ConfigureServices(app.Services);

            return app;
        }
    }
}
