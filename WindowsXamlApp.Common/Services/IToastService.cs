using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsXamlApp.Common.Services
{
    public interface IToastService
    {
        Task ShowAsync(string message, long duration = 3000, double fontSize = 16.0);
    }
}
