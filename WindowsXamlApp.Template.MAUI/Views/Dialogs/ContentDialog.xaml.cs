using WindowsXamlApp.Template.MAUI.Controls;

namespace WindowsXamlApp.Template.MAUI.Views.Dialogs;

public partial class ContentDialog : UserDialog
{
	public ContentDialog()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		this.Close(true);
    }
}