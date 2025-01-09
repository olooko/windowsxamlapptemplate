using WindowsXamlApp.Common.ViewModels.Dialogs;
using WindowsXamlApp.Template.WinUI.Controls;

namespace WindowsXamlApp.Template.WinUI.Views.Dialogs
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
