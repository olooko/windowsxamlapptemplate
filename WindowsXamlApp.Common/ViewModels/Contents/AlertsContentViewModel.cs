using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Common.ViewModels.Contents
{
    public partial class AlertsContentViewModel : ViewModelBase
    {
        private readonly IToastService _toastService;

        public AlertsContentViewModel()
        {
            _toastService = Ioc.Default.GetRequiredService<IToastService>();
        }

        [RelayCommand]
        private void ShowToast()
        {
            _toastService.Show("AAAAAAAAAAAAAAAAA");
        }
    }
}
