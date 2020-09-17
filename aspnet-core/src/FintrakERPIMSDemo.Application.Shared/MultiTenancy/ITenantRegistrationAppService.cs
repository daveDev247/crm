using System.Threading.Tasks;
using Abp.Application.Services;
using FintrakERPIMSDemo.Editions.Dto;
using FintrakERPIMSDemo.MultiTenancy.Dto;

namespace FintrakERPIMSDemo.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}