using System.ComponentModel;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.MAUI.Views;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class DialogService : IDialogService
    {
        //public object? GetService(Type serviceType)
        //{
        //    return null;
        //}

        public void ShowModalAsync<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            var currentPage = App.Current!.Windows[0].Page as ContentPage;

            //Activator.CreateInstance(typeof(T)) as ViewModelBase 

            if (currentPage != null)
            {
                var newPage = new ContentPage
                {
                    BackgroundColor = Color.FromArgb("#88000000"),
                    //Content = ,
                };

                currentPage.Navigation.PushModalAsync(newPage);
            }
        }
    }
}
