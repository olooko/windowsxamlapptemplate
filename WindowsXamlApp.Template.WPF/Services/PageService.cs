using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.WPF.Services
{
    public sealed class PageService : IPageService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public static void AddSingleton<TPage, TPageViewModel>(IServiceCollection services)
            where TPage : Page
            where TPageViewModel : ViewModelBase
        {
            _viewModelToViewMappings.Add(typeof(TPageViewModel), typeof(TPage));

            services.AddSingleton(typeof(TPage));
            services.AddSingleton(typeof(TPageViewModel));
        }

        public static void AddTransient<TPage, TPageViewModel>(IServiceCollection services)
            where TPage : Page
            where TPageViewModel : ViewModelBase
        {
            _viewModelToViewMappings.Add(typeof(TPageViewModel), typeof(TPage));

            services.AddTransient(typeof(TPage));
            services.AddTransient(typeof(TPageViewModel));
        }

        public async Task NavigateAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            var page = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as Page;

            window.MainFrame.Navigate(page);

            await Task.CompletedTask;
        }

        public async Task GoBackAsync()
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.MainFrame.GoBack();

            await Task.CompletedTask;
        }
    }
}
