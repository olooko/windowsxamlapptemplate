using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Template.WPF.Controls;

namespace WindowsXamlApp.Template.WPF.Services
{
    public sealed class DialogService : IDialogService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public static void AddSingleton<TDialog, TDialogViewModel>(IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : INotifyPropertyChanged
        {
            _viewModelToViewMappings.Add(typeof(TDialogViewModel), typeof(TDialog));

            services.AddSingleton(typeof(TDialog));
            services.AddSingleton(typeof(TDialogViewModel));
        }

        public static void AddTransient<TDialog, TDialogViewModel>(IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : INotifyPropertyChanged
        {
            _viewModelToViewMappings.Add(typeof(TDialogViewModel), typeof(TDialog));

            services.AddTransient(typeof(TDialog));
            services.AddTransient(typeof(TDialogViewModel));
        }

        public async Task<bool> ShowModalAsync<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            
            window.DialogContent.Visibility = Visibility.Visible;

            var userDialog = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as UserDialog;
            window.DialogContent.Child = userDialog;

            bool result = false;

            if (userDialog != null)
                result = await userDialog.WaitAsync();

            window.DialogContent.Visibility = Visibility.Collapsed;
            window.DialogContent.Child = null;

            return result;
        }
    }
}
