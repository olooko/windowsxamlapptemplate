namespace WindowsXamlApp.Template.MAUI.Controls
{
    public class UserDialog : ContentView
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
            var parentPage = this.Parent as ContentPage;
            parentPage!.Navigation.PopModalAsync(false);

            _taskCompletionSource.SetResult(result);
        }
    }
}
