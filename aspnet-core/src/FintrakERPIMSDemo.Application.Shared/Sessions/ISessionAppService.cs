using System.Threading.Tasks;
using Abp.Application.Services;
using FintrakERPIMSDemo.Sessions.Dto;

namespace FintrakERPIMSDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
