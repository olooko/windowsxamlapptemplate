using Microsoft.Extensions.DependencyInjection;
using System;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.WinUI.Bases;

namespace WindowsXamlApp.Template.WinUI.Views
{
    public sealed partial class MainView : ViewBase
    {
        private readonly IServiceProvider _serviceProvider;

        public MainView(MainViewModel viewModel, IServiceProvider serviceProvider)
        {
            this.InitializeComponent();

            this.DataContext = viewModel;

            _serviceProvider = serviceProvider;
        }

        private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //var window = _serviceProvider.GetRequiredService<MainWindow>();
            //window.ShowToast();
        }
    }
}
