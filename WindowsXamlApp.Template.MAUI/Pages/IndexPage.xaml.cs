using WindowsXamlApp.Common.ViewModels;

namespace WindowsXamlApp.Template.MAUI.Pages;

public partial class IndexPage : ContentPage
{
	public IndexPage(IndexPageViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}
}