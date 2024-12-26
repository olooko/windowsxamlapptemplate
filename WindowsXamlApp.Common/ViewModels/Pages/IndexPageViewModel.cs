using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WindowsXamlApp.Common.Models;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Dialogs;

namespace WindowsXamlApp.Common.ViewModels.Pages
{
    public partial class IndexPageViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IPickerService _pickerService;

        [ObservableProperty]
        private ObservableCollection<MenuListItemModel> _menuList;

        [ObservableProperty]
        private MenuListItemModel? _selectedMenuListItem;

        [ObservableProperty]
        private string? _selectedText;

        //private System.Timers.Timer _timer;

        //[ObservableProperty]
        //private string? _currentTimeString;

        public IndexPageViewModel(IDialogService dialogService, IPickerService pickerService)
        {
            _dialogService = dialogService;
            _pickerService = pickerService;

            _menuList = new ObservableCollection<MenuListItemModel>();
            _menuList.Add(new MenuListItemModel { Title = "Controls", Code = 1 });
            _menuList.Add(new MenuListItemModel { Title = "Alerts", Code = 2 });


            //_timer = new System.Timers.Timer();
            //_timer.Interval = 500;
            //_timer.Elapsed += Timer_Elapsed;
            //_timer.Start();
        }

        [RelayCommand]
        private void MenuListItemSelected()
        {
            this.SelectedText = string.Format("[{0}] is selected.", this.SelectedMenuListItem.Title);
        }

        //private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        //{
        //    _timer.Stop();


        //    this.CurrentTimeString = DateTime.Now.ToString();

        //    _timer.Start();
        //}

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
