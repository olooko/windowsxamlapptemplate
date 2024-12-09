using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public sealed class DialogService : IDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        public DialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowModalAsync<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            //ContentDialog noWifiDialog = new ContentDialog()
            //{
            //    //XamlRoot = this.XamlRoot,
            //    Title = "No wifi connection",
            //    Content = "Check connection and try again.",
            //    CloseButtonText = "Ok"
            //};


            //var currentPage = _serviceProvider.GetRequiredService<MainWindow>().Content as Page;

            ////Activator.CreateInstance(typeof(T)) as ViewModelBase 

            //if (currentPage != null)
            //{
            //    var newPage = new Page
            //    {
            //        //Background = new BrushConverter().ConvertFromString("#88000000") as SolidColorBrush,
            //        //Content = ,
            //    };

            //    currentPage.PushModalAsync(newPage);
            //}
        }
    }
}
