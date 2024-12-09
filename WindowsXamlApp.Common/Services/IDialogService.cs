using System.ComponentModel;

namespace WindowsXamlApp.Common.Services
{
    public interface IDialogService
    {
        Task<bool> ShowModalAsync<TViewModel>() where TViewModel : INotifyPropertyChanged;
    }
}
