using Microsoft.UI.Xaml.Controls;
using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.WinUI.Views
{
    public sealed partial class IndexPage : Page
    {
        public IndexPage(IndexPageViewModel viewModel)
        {
            this.InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
