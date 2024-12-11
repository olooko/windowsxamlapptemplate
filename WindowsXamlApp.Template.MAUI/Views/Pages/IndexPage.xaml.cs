using WindowsXamlApp.Common.ViewModels.Pages;

namespace WindowsXamlApp.Template.MAUI.Views.Pages;

public partial class IndexPage : ContentPage
{
	public IndexPage(IndexPageViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}
}