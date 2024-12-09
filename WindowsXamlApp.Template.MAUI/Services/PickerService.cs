using System;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
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
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { DevicePlatform.WinUI, new[] { ".cbr", ".cbz" } }, // file extension
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                });

            PickOptions options = new()
            {
                PickerTitle = "Please select a comic file",
                FileTypes = customFileType,
            };

            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }
    }
}
