using CommunityToolkit.Maui;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class PageService : IPageService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public static void AddSingleton<TPage, TPageViewModel>(IServiceCollection services)
            where TPage : Page
            where TPageViewModel : ViewModelBase
        {
            _viewModelToViewMappings.Add(typeof(TPageViewModel), typeof(TPage));

            services.AddSingletonWithShellRoute<TPage, TPageViewModel>(typeof(TPage).Name);
        }

        public static void AddTransient<TPage, TPageViewModel>(IServiceCollection services)
            where TPage : Page
            where TPageViewModel : ViewModelBase
        {
            _viewModelToViewMappings.Add(typeof(TPageViewModel), typeof(TPage));

            services.AddTransientWithShellRoute<TPage, TPageViewModel>(typeof(TPage).Name);
        }

        public async Task NavigateAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            await Shell.Current.GoToAsync(_viewModelToViewMappings[typeof(TViewModel)].Name);
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
