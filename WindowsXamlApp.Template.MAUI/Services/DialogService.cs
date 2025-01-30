using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Template.MAUI.Controls;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class DialogService : IDialogService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public DialogService()
        {
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
            bool result = false;

            var window = App.Current!.Windows[0];

            var currentPage = window.Page as ContentPage;

            var userDialog = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as UserDialog;

            if (currentPage != null && userDialog != null)
            {
                var newPage = new ContentPage
                {
                    BackgroundColor = Color.FromArgb("#88000000"),
                    Content = userDialog,
                };

                await currentPage.Navigation.PushModalAsync(newPage, false);
                result = await userDialog.WaitAsync();
            }

            return result;
        }
    }
}