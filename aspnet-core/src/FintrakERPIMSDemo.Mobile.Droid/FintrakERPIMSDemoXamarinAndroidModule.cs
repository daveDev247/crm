using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo
{
    [DependsOn(typeof(FintrakERPIMSDemoXamarinSharedModule))]
    public class FintrakERPIMSDemoXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoXamarinAndroidModule).GetAssembly());
        }
    }
}