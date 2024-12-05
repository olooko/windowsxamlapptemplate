using Microsoft.Extensions.DependencyInjection;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WPF.Bases;

namespace WindowsXamlApp.Template.WPF.Views
{
    public partial class MainView : ViewBase
    {
        protected readonly IServiceProvider _serviceProvider;

        public MainView(MainViewModel viewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            this.DataContext = viewModel;

            _serviceProvider = serviceProvider;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            window.ShowToast();
        }
    }
}
