using WindowsXamlApp.Template.MAUI.Views;

namespace WindowsXamlApp.Template.MAUI
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var indexPage = _serviceProvider.GetRequiredService<IndexPage>();
            return new MainWindow(indexPage);
        }
    }
}