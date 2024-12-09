using Microsoft.Win32;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WPF.Services
{
    public sealed class PickerService : IPickerService
    {
        public void OpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
            }
        }
    }
}
