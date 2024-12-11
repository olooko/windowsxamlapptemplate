using System.Windows.Controls;
using WindowsXamlApp.Common.ViewModels.Pages;

namespace WindowsXamlApp.Template.WPF.Views.Pages
{
    public partial class IndexPage : Page
    {
        public IndexPage(IndexPageViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
