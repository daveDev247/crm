using System.Threading.Tasks;
using Abp.Application.Services;
using FintrakERPIMSDemo.Configuration.Tenants.Dto;

namespace FintrakERPIMSDemo.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
