using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;
using WindowsXamlApp.Template.WPF.Controls;
using WindowsXamlApp.Template.WPF.Services;

namespace WindowsXamlApp.Template.WPF.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSingletonDialog<TDialog, TDialogViewModel>(this IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : INotifyPropertyChanged
        {
            DialogService.AddSingleton<TDialog, TDialogViewModel>(services);
            return services;
        }

        public static IServiceCollection AddTransientDialog<TDialog, TDialogViewModel>(this IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : INotifyPropertyChanged
        {
            DialogService.AddTransient<TDialog, TDialogViewModel>(services);
            return services;
        }

        public static IServiceCollection AddSingletonPage<TPage, TPageViewModel>(this IServiceCollection services)
            where TPage : Page
            where TPageViewModel : INotifyPropertyChanged
        {
            PageService.AddSingleton<TPage, TPageViewModel>(services);
            return services;
        }

        public static IServiceCollection AddTransientPage<TPage, TPageViewModel>(this IServiceCollection services)
            where TPage : Page
            where TPageViewModel : INotifyPropertyChanged
        {
            PageService.AddTransient<TPage, TPageViewModel>(services);
            return services;
        }
    }
}
