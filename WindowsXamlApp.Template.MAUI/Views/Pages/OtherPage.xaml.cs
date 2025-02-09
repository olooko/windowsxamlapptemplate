using CommunityToolkit.Mvvm.DependencyInjection;
using WindowsXamlApp.Common.ViewModels.Pages;

namespace WindowsXamlApp.Template.MAUI.Views.Pages;

public partial class OtherPage : ContentPage
{
	public OtherPage(OtherPageViewModel voiewModel)
	{
		InitializeComponent();

		this.BindingContext = Ioc.Default.GetRequiredService<OtherPageViewModel>();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}