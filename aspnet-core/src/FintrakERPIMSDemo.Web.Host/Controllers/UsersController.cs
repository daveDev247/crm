using Abp.AspNetCore.Mvc.Authorization;
using FintrakERPIMSDemo.Authorization;
using FintrakERPIMSDemo.Storage;
using Abp.BackgroundJobs;

namespace FintrakERPIMSDemo.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}