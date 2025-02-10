using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Common.Services
{
    public interface IPageService
    {
        Task NavigateAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task GoBackAsync();
    }
}
