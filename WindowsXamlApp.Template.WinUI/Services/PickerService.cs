using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.Storage.Pickers;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public sealed class PickerService : IPickerService
    {
        private readonly IServiceProvider _serviceProvider;

        public PickerService(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
        }

        public async void OpenFile()
        {
            var openPicker = new FileOpenPicker();

            var window = _serviceProvider.GetRequiredService<MainWindow>();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add("*");

            var file = await openPicker.PickSingleFileAsync();
        }
    }
}
