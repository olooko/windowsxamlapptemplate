using System.Windows.Controls;
using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.WPF.Pages
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
