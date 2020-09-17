using System.Collections.Generic;
using MvvmHelpers;
using FintrakERPIMSDemo.Models.NavigationMenu;

namespace FintrakERPIMSDemo.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}