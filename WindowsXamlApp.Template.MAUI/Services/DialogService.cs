using System.ComponentModel;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Template.MAUI.Controls;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class DialogService : IDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public DialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
            var window = App.Current!.Windows[0];

            var currentPage = window.Page as ContentPage;

            var userDialog = _serviceProvider.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as UserDialog;

            if (currentPage != null)
            {
                var newPage = new ContentPage
                {
                    BackgroundColor = Color.FromArgb("#88000000"),
                    Content = userDialog,
                };

                await currentPage.Navigation.PushModalAsync(newPage);
            }


            bool result = false;

            //if (userDialog != null)
            //    result = await userDialog.WaitAsync();

            //window.DialogContent.Visibility = Visibility.Collapsed;
            //window.DialogContent.Child = null;

            return result;
        }
    }
}