using Abp.Application.Services;
using FintrakERPIMSDemo.Dto;
using FintrakERPIMSDemo.Logging.Dto;

namespace FintrakERPIMSDemo.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
