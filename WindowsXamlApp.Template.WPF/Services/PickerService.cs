using Microsoft.Win32;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WPF.Services
{
    public sealed class PickerService : IPickerService
    {
        public async Task<string> OpenFileAsync()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
                return await Task.FromResult(dialog.FileName);
            
            return await Task.FromResult(string.Empty);
        }

        public async Task<string> SaveFileAsync()
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "FileName";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
                return await Task.FromResult(dialog.FileName);

            return await Task.FromResult(string.Empty);
        }

        public void SelectColor()
        {
            //var dialog = new Dial ColorDialog();
            //dialog.ShowDialog();
        }
    }
}
