using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FintrakERPIMSDemo.Authorization;

namespace FintrakERPIMSDemo
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(FintrakERPIMSDemoApplicationSharedModule),
        typeof(FintrakERPIMSDemoCoreModule)
        )]
    public class FintrakERPIMSDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoApplicationModule).GetAssembly());
        }
    }
}