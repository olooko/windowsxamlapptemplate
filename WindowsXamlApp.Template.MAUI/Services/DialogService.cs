using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Template.MAUI.Dialogs;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public class DialogService : IDialogService
    {
        public void Modal()
        {
            var currentPage = App.Current!.Windows[0].Page as ContentPage;

            if (currentPage != null)
            {
                var newPage = new ContentPage
                {
                    BackgroundColor = Color.FromArgb("#88000000"),
                    Content = new ContentDialog(),
                    Parent = currentPage,
                };

                currentPage.Navigation.PushModalAsync(newPage);
            }
        }
    }
}
