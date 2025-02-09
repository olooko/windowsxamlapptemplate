namespace WindowsXamlApp.Template.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());

            //var window = Ioc.Default.GetRequiredService<MainWindow>();

            //Ioc.Default.GetRequiredService<IPageService>().Navigate<IndexPageViewModel>();

            //window.
            //window.Page = Ioc.Default.GetRequiredService<IndexPage>();
            //return window;
        }
    }
}