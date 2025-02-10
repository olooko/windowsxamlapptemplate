using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.MAUI.Controls;
using WindowsXamlApp.Template.MAUI.Services;

namespace WindowsXamlApp.Template.MAUI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSingletonDialog<TDialog, TDialogViewModel>(this IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : ViewModelBase
        {
            DialogService.AddSingleton<TDialog, TDialogViewModel>(services);
            return services;
        }

        public static IServiceCollection AddTransientDialog<TDialog, TDialogViewModel>(this IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : ViewModelBase
        {
            DialogService.AddTransient<TDialog, TDialogViewModel>(services);
            return services;
        }

        public static IServiceCollection AddSingletonPage<TPage, TPageViewModel>(this IServiceCollection services)
            where TPage : Page
            where TPageViewModel : ViewModelBase
        {
            PageService.AddSingleton<TPage, TPageViewModel>(services);
            return services;
        }

        public static IServiceCollection AddTransientPage<TPage, TPageViewModel>(this IServiceCollection services)
            where TPage : Page
            where TPageViewModel : ViewModelBase
        {
            PageService.AddTransient<TPage, TPageViewModel>(services);
            return services;
        }
    }
}
