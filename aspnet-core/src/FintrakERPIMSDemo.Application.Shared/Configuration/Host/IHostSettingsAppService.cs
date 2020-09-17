using System.Threading.Tasks;
using Abp.Application.Services;
using FintrakERPIMSDemo.Configuration.Host.Dto;

namespace FintrakERPIMSDemo.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
