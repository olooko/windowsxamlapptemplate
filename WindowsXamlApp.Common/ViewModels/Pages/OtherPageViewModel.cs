using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Common.ViewModels.Pages
{
    public partial class OtherPageViewModel : ViewModelBase
    {
        [RelayCommand]
        private async Task GoBack()
        {
            await Ioc.Default.GetRequiredService<IPageService>().GoBackAsync();
        }
    }
}
