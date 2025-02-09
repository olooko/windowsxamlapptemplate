using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WPF.Services
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
            var page = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as Page;

            window.MainFrame.Navigate(page);
        }

        public void GoBack()
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.MainFrame.GoBack();
        }
    }
}
