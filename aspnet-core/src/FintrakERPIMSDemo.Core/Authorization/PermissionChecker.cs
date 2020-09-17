using Abp.Authorization;
using FintrakERPIMSDemo.Authorization.Roles;
using FintrakERPIMSDemo.Authorization.Users;

namespace FintrakERPIMSDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
