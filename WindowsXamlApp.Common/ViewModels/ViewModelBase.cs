using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsXamlApp.Common.ViewModels
{
    public class ViewModelBase : ObservableRecipient
    {
        public ViewModelBase()
        {
        }

        public virtual void ExtraDataReceived(object extraData) { }
    }
}
