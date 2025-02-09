using WindowsXamlApp.Template.MAUI.Views.Pages;

namespace WindowsXamlApp.Template.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("IndexPage", typeof(IndexPage));
            Routing.RegisterRoute("OtherPage", typeof(OtherPage));
        }
    }
}
