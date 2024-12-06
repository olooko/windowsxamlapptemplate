using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Common.ViewModels
{
    public partial class IndexPageViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IToastService _toastService;

        private System.Timers.Timer _timer;

        [ObservableProperty]
        private string? _currentTimeString;

        public IndexPageViewModel(IDialogService dialogService, IToastService toastService)
        {
            _dialogService = dialogService;
            _toastService = toastService;

            _timer = new System.Timers.Timer();
            _timer.Interval = 500;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();

            this.CurrentTimeString = DateTime.Now.ToString();

            _timer.Start();
        }

        [RelayCommand]
        private void ShowToast(object message)
        {
            _dialogService.Modal();
            //_toastService.Show(message as string);
        }
    }
}
