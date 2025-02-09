using CommunityToolkit.Maui;
using System.ComponentModel;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
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

            //services.AddTransientWithShellRoute<TPage, TPageViewModel>(nameof(TPage));
        }

        public void Navigate<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            //Shell.Current
            //var window = Ioc.Default.GetRequiredService<MainWindow>();

            //var page = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as Page;

            //window.Page = page;
            //window.MainFrame.Navigate(_viewModelToViewMappings[typeof(TViewModel)], null, new SuppressNavigationTransitionInfo());

            //Shell.Current.GoToAsync(nameof(_viewModelToViewMappings[typeof(TViewModel)]));
        }

        public void GoBack()
        {
            //var window = Ioc.Default.GetRequiredService<MainWindow>();
            //window.Navigation.PopAsync();
        }
    }
}
