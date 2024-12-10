using System.ComponentModel;
using WindowsXamlApp.Template.MAUI.Controls;
using WindowsXamlApp.Template.MAUI.Services;

namespace WindowsXamlApp.Template.MAUI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTransientDialog<TDialog, TDialogViewModel>(this IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : INotifyPropertyChanged
        {
            DialogService.AddTransient<TDialog, TDialogViewModel>(services);
            return services;
        }
    }
}
