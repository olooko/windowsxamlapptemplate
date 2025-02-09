using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WebUI;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Template.WinUI.Views.Pages;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public sealed class PageService : IPageService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public static void AddSingleton<TPage, TPageViewModel>(IServiceCollection services)
            where TPage : Page
            where TPageViewModel : INotifyPropertyChanged
        {
            _viewModelToViewMappings.Add(typeof(TPageViewModel), typeof(TPage));

            services.AddSingleton(typeof(TPage));
            services.AddSingleton(typeof(TPageViewModel));
        }

        public static void AddTransient<TPage, TPageViewModel>(IServiceCollection services)
            where TPage : Page
            where TPageViewModel : INotifyPropertyChanged
        {
            _viewModelToViewMappings.Add(typeof(TPageViewModel), typeof(TPage));

            services.AddTransient(typeof(TPage));
            services.AddTransient(typeof(TPageViewModel));
        }

        public void Navigate<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.MainFrame.Navigate(_viewModelToViewMappings[typeof(TViewModel)], null, new SuppressNavigationTransitionInfo());
        }

        public void GoBack()
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.MainFrame.GoBack();
        }
    }
}
