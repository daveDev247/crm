using System.Collections.Generic;
using FintrakERPIMSDemo.Authorization.Permissions.Dto;

namespace FintrakERPIMSDemo.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}