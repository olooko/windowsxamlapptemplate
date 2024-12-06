using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsXamlApp.Common.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _welcomeText;

        public MainPageViewModel()
        {
            _welcomeText = "Welcome to XAML App.";
        }
    }
}
