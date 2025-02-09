using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public sealed class PickerService : IPickerService
    {
        public async Task<string> OpenFileAsync()
        {
            var openPicker = new FileOpenPicker();

            var window = Ioc.Default.GetRequiredService<MainWindow>();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add(".txt");

            var file = openPicker.PickSingleFileAsync().GetAwaiter().GetResult();

            if (file != null)
                return await Task.FromResult(file.Path);

            return await Task.FromResult(string.Empty);
        }

        public async Task<string> SaveFileAsync()
        {
            var savePicker = new FileSavePicker();

            var window = Ioc.Default.GetRequiredService<MainWindow>();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            WinRT.Interop.InitializeWithWindow.Initialize(savePicker, hWnd);

            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "FileName";

            var file = savePicker.PickSaveFileAsync().GetAwaiter().GetResult();

            if (file != null)
                return await Task.FromResult(file.Path);

            return await Task.FromResult(string.Empty);
        }
    }
}
