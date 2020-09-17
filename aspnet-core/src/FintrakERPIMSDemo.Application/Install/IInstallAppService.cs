using System.Threading.Tasks;
using Abp.Application.Services;
using FintrakERPIMSDemo.Install.Dto;

namespace FintrakERPIMSDemo.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}