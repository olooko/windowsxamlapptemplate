using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using WindowsXamlApp.Template.WPF.Controls;
using WindowsXamlApp.Template.WPF.Services;

namespace WindowsXamlApp.Template.WPF.Extensions
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
