using System.Threading.Tasks;
using Abp.Application.Services;

namespace FintrakERPIMSDemo.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
