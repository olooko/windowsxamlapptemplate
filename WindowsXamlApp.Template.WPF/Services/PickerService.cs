using Microsoft.Win32;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WPF.Services
{
    public sealed class PickerService : IPickerService
    {
        public string OpenFile()
        {
            var dialog = new OpenFileDialog();
            //dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
                return dialog.FileName;
            
            return string.Empty;
        }

        public string SaveFile()
        {
            var dialog = new SaveFileDialog();
            //dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
                return dialog.FileName;
            
            return string.Empty;
        }
    }
}
