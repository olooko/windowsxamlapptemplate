using WindowsXamlApp.Template.WPF.Controls;

namespace WindowsXamlApp.Template.WPF.Views
{
    public partial class ContentDialog : UserDialog
    {
        public ContentDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close(false);
        }
    }
}
