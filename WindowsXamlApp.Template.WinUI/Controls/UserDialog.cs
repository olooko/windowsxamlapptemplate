using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsXamlApp.Template.WinUI.Controls
{
    public class UserDialog : UserControl
    {
        private TaskCompletionSource<bool> _taskCompletionSource;
        private CancellationToken _cancellationToken;

        public UserDialog()
        {
            _taskCompletionSource = new TaskCompletionSource<bool>();
            _cancellationToken = new CancellationToken();
        }

        public async Task<bool> WaitAsync()
        {
            return await _taskCompletionSource.Task.WaitAsync(_cancellationToken);
        }

        public void Close(bool result)
        {
            _taskCompletionSource.SetResult(result);
        }
    }
}
