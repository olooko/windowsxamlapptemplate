using WindowsXamlApp.Template.MAUI.Controls;

namespace WindowsXamlApp.Template.MAUI.Views;

public partial class ContentDialog : UserDialog
{
	public ContentDialog()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var parentPage = this.Parent as ContentPage;
		parentPage!.Navigation.PopModalAsync();
    }
}