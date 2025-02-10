using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class PickerService : IPickerService
    {
        public PickerService()
        {
        }

        public async Task<string> OpenFileAsync()
        {
            //var options = new PickOptions
            //{
            //    FileTypes = new FilePickerFileType(
            //    new Dictionary<DevicePlatform, IEnumerable<string>>
            //    {
            //        { DevicePlatform.iOS, new[] { "public.text" } },
            //        { DevicePlatform.Android, new[] { "text/plain" } },
            //        { DevicePlatform.WinUI, new[] { ".txt" } },
            //        { DevicePlatform.macOS, new[] { "txt" } },
            //    })
            //};

            //var result = FilePicker.PickAsync(options).GetAwaiter().GetResult();

            //if (result != null)
            //    return result.FullPath;

            return await Task.FromResult(string.Empty);
        }

        public async Task<string> SaveFileAsync()
        {
            return await Task.FromResult(string.Empty);
        }
    }
}
