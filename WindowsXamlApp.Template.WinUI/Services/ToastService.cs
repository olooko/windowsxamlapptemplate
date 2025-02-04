using CommunityToolkit.Mvvm.DependencyInjection;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public class ToastService : IToastService
    {
        public void Show(string message)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.ToastContent.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
        }
    }
}
