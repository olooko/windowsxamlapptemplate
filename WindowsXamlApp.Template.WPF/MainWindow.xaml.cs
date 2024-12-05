using System.Windows;
using WindowsXamlApp.Template.WPF.Bases;

namespace WindowsXamlApp.Template.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetView(ViewBase viewBase)
        {
            this.View.Content = viewBase;
        }

        public void ShowToast()
        {
            //this.Toast.Visibility = Visibility.Visible;
        }
    }
}