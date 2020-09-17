using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo
{
    [DependsOn(typeof(FintrakERPIMSDemoXamarinSharedModule))]
    public class FintrakERPIMSDemoXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoXamarinIosModule).GetAssembly());
        }
    }
}