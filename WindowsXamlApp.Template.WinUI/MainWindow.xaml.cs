using Microsoft.UI.Xaml;
using WindowsXamlApp.Template.WinUI.Bases;

namespace WindowsXamlApp.Template.WinUI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        public void SetView(ViewBase viewBase)
        {
            this.View.Content = viewBase;
        }
    }
}
