namespace WindowsXamlApp.Template.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SetView(ContentView? contentView)
        {
            if (contentView != null)
            {
                //contentView.Content.Scale = (DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density) / 1920;
                this.View.Content = contentView;
            }
        }
    }

}
