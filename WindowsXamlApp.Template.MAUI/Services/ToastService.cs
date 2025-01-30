using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class ToastService : IToastService
    {
        public void Show(string message)
        {
            var window = App.Current!.Windows[0];

            window.AddOverlay(new LoadingOverlay(window));

            var currentPage = window.Page as ContentPage;

            if (currentPage != null)
            {
                //currentPage.AddLogicalChild(new Border
                //{
                //    WidthRequest = 300,
                //    HeightRequest = 200,
                //    BackgroundColor = Colors.AliceBlue,
                //    Content = new Label { Text = message },
                //});
                //var newPage = new ContentPage
                //{
                //    BackgroundColor = Color.FromArgb("#88000000"),
                //    Content = userDialog,
                //};

                //await currentPage.Navigation.PushModalAsync(newPage, false);
                //result = await userDialog.WaitAsync();
            }

            //System.Diagnostics.Trace.WriteLine(App.Current.MainPage.
        }
    }
}
