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
        private readonly IServiceProvider _serviceProvider;

        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public DialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        internal static void AddTransientDialog<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TDialog, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TDialogViewModel>(IServiceCollection services)
            where TDialog : UserControl
            where TDialogViewModel : INotifyPropertyChanged
        {
            _viewModelToViewMappings.Add(typeof(TDialogViewModel), typeof(TDialog));

            services.AddTransient(typeof(TDialog));
            services.AddTransient(typeof(TDialogViewModel));
        }

        public async Task<bool> ShowModalAsync<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            
            window.DialogContent.Visibility = Visibility.Visible;

            var userDialog = _serviceProvider.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as UserDialog;
            window.DialogContent.Child = userDialog;

            bool result = false;

            if (userDialog != null)
                result = await userDialog.WaitAsync();

            window.DialogContent.Visibility = Visibility.Hidden;
            window.DialogContent.Child = null;

            return result;
        }
    }
}
