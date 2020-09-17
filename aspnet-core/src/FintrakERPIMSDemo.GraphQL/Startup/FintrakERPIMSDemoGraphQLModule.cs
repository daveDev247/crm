using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo.Startup
{
    [DependsOn(typeof(FintrakERPIMSDemoCoreModule))]
    public class FintrakERPIMSDemoGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}