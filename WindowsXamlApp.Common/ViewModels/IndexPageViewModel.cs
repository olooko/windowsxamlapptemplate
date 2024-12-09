using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Common.ViewModels
{
    public partial class IndexPageViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IPickerService _pickerService;

        private System.Timers.Timer _timer;

        [ObservableProperty]
        private string? _currentTimeString;

        public IndexPageViewModel(IDialogService dialogService, IPickerService pickerService)
        {
            _dialogService = dialogService;
            _pickerService = pickerService;

            _timer = new System.Timers.Timer();
            _timer.Interval = 500;
            _timer.Elapsed += Timer_Elapsed;
            //_timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();

            
            this.CurrentTimeString = DateTime.Now.ToString();

            _timer.Start();
        }

        [RelayCommand]
        private void OpenFile()
        {
            _pickerService.OpenFile();
        }

        [RelayCommand]
        private async Task ShowDialog(object message)
        {
            bool result = await _dialogService.ShowModalAsync<ContentDialogViewModel>();
        }

    }
}
