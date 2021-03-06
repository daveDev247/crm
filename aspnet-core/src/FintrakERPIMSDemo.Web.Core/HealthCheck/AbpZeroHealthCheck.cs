﻿using Microsoft.Extensions.DependencyInjection;
using FintrakERPIMSDemo.HealthChecks;

namespace FintrakERPIMSDemo.Web.HealthCheck
{
    public static class AbpZeroHealthCheck
    {
        public static IHealthChecksBuilder AddAbpZeroHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<FintrakERPIMSDemoDbContextHealthCheck>("Database Connection");
            builder.AddCheck<FintrakERPIMSDemoDbContextUsersHealthCheck>("Database Connection with user check");
            builder.AddCheck<CacheHealthCheck>("Cache");

            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
