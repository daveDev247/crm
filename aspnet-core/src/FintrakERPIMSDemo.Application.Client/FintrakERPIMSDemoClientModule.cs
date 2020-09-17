﻿using Abp.Modules;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo
{
    public class FintrakERPIMSDemoClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FintrakERPIMSDemoClientModule).GetAssembly());
        }
    }
}
