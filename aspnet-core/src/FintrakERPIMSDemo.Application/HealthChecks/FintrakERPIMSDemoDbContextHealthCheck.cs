using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using FintrakERPIMSDemo.EntityFrameworkCore;

namespace FintrakERPIMSDemo.HealthChecks
{
    public class FintrakERPIMSDemoDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public FintrakERPIMSDemoDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("FintrakERPIMSDemoDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("FintrakERPIMSDemoDbContext could not connect to database"));
        }
    }
}
