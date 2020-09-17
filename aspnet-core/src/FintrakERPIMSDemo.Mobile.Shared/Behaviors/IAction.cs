using Xamarin.Forms.Internals;

namespace FintrakERPIMSDemo.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}