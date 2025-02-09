using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsXamlApp.Common.Services
{
    public interface IPageService
    {
        void Navigate<TViewModel>() where TViewModel : INotifyPropertyChanged;
        void GoBack();
    }
}
