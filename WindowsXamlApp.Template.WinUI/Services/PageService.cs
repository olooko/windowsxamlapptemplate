using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.WinUI.Services
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
            window.MainFrame.Navigate(_viewModelToViewMappings[typeof(TViewModel)], null, new SuppressNavigationTransitionInfo());

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
