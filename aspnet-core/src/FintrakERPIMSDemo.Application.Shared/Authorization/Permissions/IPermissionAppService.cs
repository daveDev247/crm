using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Authorization.Permissions.Dto;

namespace FintrakERPIMSDemo.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
