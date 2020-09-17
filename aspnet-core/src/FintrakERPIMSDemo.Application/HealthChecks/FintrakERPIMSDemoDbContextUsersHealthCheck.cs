﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using FintrakERPIMSDemo.EntityFrameworkCore;

namespace FintrakERPIMSDemo.HealthChecks
{
    public class FintrakERPIMSDemoDbContextUsersHealthCheck : IHealthCheck
    {
        private readonly IDbContextProvider<FintrakERPIMSDemoDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public FintrakERPIMSDemoDbContextUsersHealthCheck(
            IDbContextProvider<FintrakERPIMSDemoDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager
            )
        {
            _dbContextProvider = dbContextProvider;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var uow = _unitOfWorkManager.Begin())
                {
                    // Switching to host is necessary for single tenant mode.
                    using (_unitOfWorkManager.Current.SetTenantId(null))
                    {
                        if (!await _dbContextProvider.GetDbContext().Database.CanConnectAsync(cancellationToken))
                        {
                            return HealthCheckResult.Unhealthy(
                                "FintrakERPIMSDemoDbContext could not connect to database"
                            );
                        }

                        var user = await _dbContextProvider.GetDbContext().Users.AnyAsync(cancellationToken);
                        uow.Complete();

                        if (user)
                        {
                            return HealthCheckResult.Healthy("FintrakERPIMSDemoDbContext connected to database and checked whether user added");
                        }

                        return HealthCheckResult.Unhealthy("FintrakERPIMSDemoDbContext connected to database but there is no user.");

                    }
                }
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy("FintrakERPIMSDemoDbContext could not connect to database.", e);
            }
        }
    }
}
