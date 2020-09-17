using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Common.Dto;
using FintrakERPIMSDemo.Editions.Dto;

namespace FintrakERPIMSDemo.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}