using WindowsXamlApp.Common.DialogModels;
using WindowsXamlApp.Template.WinUI.Controls;

namespace WindowsXamlApp.Template.WinUI.Views
{
    public sealed partial class ContentDialog : UserDialog
    {
        public ContentDialog(ContentDialogViewModel viewModel)
        {
            this.InitializeComponent();

            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.Close(false);
        }
    }
}
