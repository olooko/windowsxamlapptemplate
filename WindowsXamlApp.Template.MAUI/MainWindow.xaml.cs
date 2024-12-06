namespace WindowsXamlApp.Template.MAUI;

public partial class MainWindow : Window
{
	public MainWindow() : base()
	{
		InitializeComponent();
	}

    public MainWindow(Page page) : base(page)
    {
        InitializeComponent();

		this.Page = page;
    }
}