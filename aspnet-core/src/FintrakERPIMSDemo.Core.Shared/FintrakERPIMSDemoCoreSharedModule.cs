using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo
{
    public class FintrakERPIMSDemoCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoCoreSharedModule).GetAssembly());
        }
    }
}