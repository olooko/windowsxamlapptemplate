using CommunityToolkit.Mvvm.DependencyInjection;
using WindowsXamlApp.Common.ViewModels.Pages;

namespace WindowsXamlApp.Template.MAUI.Views.Pages;

public partial class IndexPage : ContentPage
{
	public IndexPage()
	{
		InitializeComponent();

		this.BindingContext = Ioc.Default.GetRequiredService<IndexPageViewModel>();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(OtherPage));
    }
}