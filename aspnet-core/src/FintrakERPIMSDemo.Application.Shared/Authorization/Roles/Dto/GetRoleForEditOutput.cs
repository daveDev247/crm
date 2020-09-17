using System.Collections.Generic;
using FintrakERPIMSDemo.Authorization.Permissions.Dto;

namespace FintrakERPIMSDemo.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}