using CommunityToolkit.Maui.Alerts;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class ToastService : IToastService
    {
        private readonly IServiceProvider _serviceProvider;

        public ToastService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Show(string message)
        {
            Toast.Make(message).Show();
        }
    }
}
