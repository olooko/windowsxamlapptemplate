using CommunityToolkit.Mvvm.ComponentModel;
using WindowsXamlApp.Common.Bases;

namespace WindowsXamlApp.Common.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _welcomeText;

        public MainViewModel()
        {
            _welcomeText = "Welcome to XAML App.";
        }
    }
}
