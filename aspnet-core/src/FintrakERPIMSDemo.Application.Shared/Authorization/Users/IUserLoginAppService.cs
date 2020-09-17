using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Authorization.Users.Dto;

namespace FintrakERPIMSDemo.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
