using Microsoft.Win32;
using System.Windows.Controls;
using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.WPF.Views
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
