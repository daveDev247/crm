using FintrakERPIMSDemo.Models.Users;
using FintrakERPIMSDemo.ViewModels;
using Xamarin.Forms;

namespace FintrakERPIMSDemo.Views
{
    public partial class UsersView : ContentPage, IXamarinView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((UsersViewModel) BindingContext).LoadMoreUserIfNeedsAsync(e.Item as UserListModel);
        }
    }
}