using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using WindowsXamlApp.Template.WinUI.Controls;
using WindowsXamlApp.Template.WinUI.Services;

namespace WindowsXamlApp.Template.WinUI.Extensions
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
