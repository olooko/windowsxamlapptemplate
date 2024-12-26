using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class ToastService : IToastService
    {
        private readonly IServiceProvider _serviceProvider;

        public ToastService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Show(string message)
        {
            bool result = false;

            var window = App.Current!.Windows[0];

            var currentPage = window.Page as ContentPage;

            if (currentPage != null)
            {
                var toast = new Border
                {
                    Content = new Label
                    {
                        Text = message,
                    }
                };
                currentPage.AddLogicalChild(toast);


                //var newPage = new ContentPage
                //{
                    //BackgroundColor = Color.FromArgb("#88000000"),
                    //Content = userDialog,
                //};

                //await currentPage.Navigation.PushModalAsync(newPage, false);
                //result = await userDialog.WaitAsync();
            }

            //return result;

        }
    }
}
