using Microsoft.UI.Xaml.Controls;

namespace WindowsXamlApp.Template.WinUI.Bases
{
    public partial class ViewBase : Page
    {
        public ViewBase()
        {
            this.InitializeComponent();
        }

        public void ShowToast()
        {
            //this.Toast.Visibility = Visibility.Visible;
        }
    }
}
