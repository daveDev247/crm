using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo
{
    [DependsOn(typeof(FintrakERPIMSDemoClientModule), typeof(AbpAutoMapperModule))]
    public class FintrakERPIMSDemoXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoXamarinSharedModule).GetAssembly());
        }
    }
}