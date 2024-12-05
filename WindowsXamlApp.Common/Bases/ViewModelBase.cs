using CommunityToolkit.Mvvm.ComponentModel;

namespace WindowsXamlApp.Common.Bases
{
    public class ViewModelBase : ObservableRecipient
    {
        public ViewModelBase()
        {
        }

        public virtual void ExtraDataReceived(object extraData) { }
    }
}
