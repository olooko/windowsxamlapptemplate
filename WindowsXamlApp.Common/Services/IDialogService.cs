using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Common.Services
{
    public interface IDialogService
    {
        Task<bool> ShowModalAsync<TViewModel>() where TViewModel : ViewModelBase;
    }
}
