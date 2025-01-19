using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WindowsXamlApp.Common.Models;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels.Dialogs;

namespace WindowsXamlApp.Common.ViewModels.Pages
{
    public partial class IndexPageViewModel : ViewModelBase
    {
        private readonly IPickerService _pickerService;
        private readonly IDialogService _dialogService;

        [ObservableProperty]
        private List<CheckBoxItemModel>? _checkBoxList;

        [ObservableProperty]
        private string? _checkBoxStateText;

        [ObservableProperty]
        private List<RadioButtonItemModel>? _radioButtonList;

        [ObservableProperty]
        private string? _radioButtonStateText;

        [ObservableProperty]
        private List<ComboBoxItemModel>? _comboBoxList;

        [ObservableProperty]
        private ComboBoxItemModel? _comboBoxSelectedItem;

        [ObservableProperty]
        private string? _comboBoxSelectionText;

        [ObservableProperty]
        private List<ListBoxItemModel>? _listBoxList;

        [ObservableProperty]
        private ListBoxItemModel? _listBoxSelectedItem;

        [ObservableProperty]
        private string? _listBoxSelectionText;

        [ObservableProperty]
        private string? _pickerSelectionText;

        //[ObservableProperty]
        //private ObservableCollection<MenuListItemModel> _menuList;

        //[ObservableProperty]
        //private MenuListItemModel? _selectedMenuListItem;

        //[ObservableProperty]
        //private string? _selectedText;

        //private System.Timers.Timer _timer;

        //[ObservableProperty]
        //private string? _currentTimeString;

        public IndexPageViewModel()
        {
            _dialogService = Ioc.Default.GetRequiredService<IDialogService>();
            _pickerService = Ioc.Default.GetRequiredService<IPickerService>();

            this.CheckBoxList = new List<CheckBoxItemModel>();
            this.CheckBoxList.Add(new CheckBoxItemModel { IsChecked = true, Code = "A", Text = "체크 A" });
            this.CheckBoxList.Add(new CheckBoxItemModel { IsChecked = false, Code = "B", Text = "체크 B" });
            this.CheckBoxList.Add(new CheckBoxItemModel { IsChecked = true, Code = "C", Text = "체크 C" });
            this.CheckBoxList.Add(new CheckBoxItemModel { IsChecked = false, Code = "D", Text = "체크 D" });

            this.RadioButtonList = new List<RadioButtonItemModel>();
            this.RadioButtonList.Add(new RadioButtonItemModel { IsChecked = false, Code = "E", Text = "라디오 E" });
            this.RadioButtonList.Add(new RadioButtonItemModel { IsChecked = false, Code = "F", Text = "라디오 F" });
            this.RadioButtonList.Add(new RadioButtonItemModel { IsChecked = true, Code = "G", Text = "라디오 G" });
            this.RadioButtonList.Add(new RadioButtonItemModel { IsChecked = false, Code = "H", Text = "라디오 H" });

            this.ComboBoxList = new List<ComboBoxItemModel>();
            this.ComboBoxList.Add(new ComboBoxItemModel { Code = "I", Text = "콤보 I" });
            this.ComboBoxList.Add(new ComboBoxItemModel { Code = "J", Text = "콤보 J" });
            this.ComboBoxList.Add(new ComboBoxItemModel { Code = "K", Text = "콤보 K" });
            this.ComboBoxList.Add(new ComboBoxItemModel { Code = "L", Text = "콤보 L" });

            this.ListBoxList = new List<ListBoxItemModel>();
            this.ListBoxList.Add(new ListBoxItemModel { Code = "M", Text = "리스트 M" });
            this.ListBoxList.Add(new ListBoxItemModel { Code = "N", Text = "리스트 N" });
            this.ListBoxList.Add(new ListBoxItemModel { Code = "O", Text = "리스트 O" });
            this.ListBoxList.Add(new ListBoxItemModel { Code = "P", Text = "리스트 P" });

            //_menuList = new ObservableCollection<MenuListItemModel>();
            //_menuList.Add(new MenuListItemModel { Title = "Controls", Code = 1 });
            //_menuList.Add(new MenuListItemModel { Title = "Alerts", Code = 2 });

            //_timer = new System.Timers.Timer();
            //_timer.Interval = 500;
            //_timer.Elapsed += Timer_Elapsed;
            //_timer.Start();
        }

        [RelayCommand]
        private void UpdateCheckBoxState(object code)
        {
            if (this.CheckBoxList != null)
            {
                CheckBoxItemModel? itemModel = this.CheckBoxList.Find(x => x.Code == (string)code);

                if (itemModel != null)
                {
                    this.CheckBoxStateText = string.Format("{0} is {1}.", itemModel.Code, itemModel.IsChecked ? "checked" : "unchecked");
                }
            }
        }

        [RelayCommand]
        private void UpdateRadioButtonState(object code)
        {
            if (this.RadioButtonList != null)
            {
                RadioButtonItemModel? itemModel = this.RadioButtonList.Find(x => x.Code == (string)code);

                if (itemModel != null)
                {
                    this.RadioButtonStateText = string.Format("{0} is {1}.", itemModel.Code, itemModel.IsChecked ? "checked" : "unchecked");
                }
            }
        }

        partial void OnComboBoxSelectedItemChanged(ComboBoxItemModel? value)
        {
            if (value != null)
            {
                this.ComboBoxSelectionText = string.Format("{0} is selected.", value.Code);
            }
        }

        partial void OnListBoxSelectedItemChanged(ListBoxItemModel? value)
        {
            if (value != null)
            {
                this.ListBoxSelectionText = string.Format("{0} is selected.", value.Code);
            }
        }

        //[RelayCommand]
        //private void MenuListItemSelected()
        //{
        //    this.SelectedText = string.Format("[{0}] is selected.", this.SelectedMenuListItem.Title);
        //}

        //private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        //{
        //    _timer.Stop();


        //    this.CurrentTimeString = DateTime.Now.ToString();

        //    _timer.Start();
        //}

        [RelayCommand]
        private void OpenFile()
        {
            this.PickerSelectionText = _pickerService.OpenFile();
        }

        [RelayCommand]
        private void SaveFile()
        {
            this.PickerSelectionText = _pickerService.SaveFile();

            // 일정 보기: 항상 표시되는 달력에서 단일 날짜 또는 날짜 범위를 선택하는 데 사용합니다.
            // 달력 날짜 선택기: 상황에 맞는 달력에서 단일 날짜를 선택하는 데 사용합니다.
            // 날짜 선택기: 컨텍스트 정보가 중요하지 않은 경우, 잘 알려진 단일 날짜를 선택하는 데 사용합니다.
            // 시간 선택기: 단일 시간 값을 선택하는 데 사용합니다.
            // 색상 선택기
        }

        [RelayCommand]
        private async Task ShowContentDialog(object message)
        {
            bool result = await _dialogService.ShowModalAsync<ContentDialogViewModel>();
        }

    }
}
