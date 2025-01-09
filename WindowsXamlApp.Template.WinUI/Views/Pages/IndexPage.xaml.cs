using Microsoft.UI.Xaml.Controls;
using WindowsXamlApp.Common.ViewModels.Pages;

namespace WindowsXamlApp.Template.WinUI.Views.Pages
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
