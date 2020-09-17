using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo
{
    [DependsOn(typeof(FintrakERPIMSDemoCoreSharedModule))]
    public class FintrakERPIMSDemoApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoApplicationSharedModule).GetAssembly());
        }
    }
}