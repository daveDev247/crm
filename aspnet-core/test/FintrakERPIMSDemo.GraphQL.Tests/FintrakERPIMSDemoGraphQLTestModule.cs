using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FintrakERPIMSDemo.Configure;
using FintrakERPIMSDemo.Startup;
using FintrakERPIMSDemo.Test.Base;

namespace FintrakERPIMSDemo.GraphQL.Tests
{
    [DependsOn(
        typeof(FintrakERPIMSDemoGraphQLModule),
        typeof(FintrakERPIMSDemoTestBaseModule))]
    public class FintrakERPIMSDemoGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoGraphQLTestModule).GetAssembly());
        }
    }
}