﻿using Abp.DynamicEntityParameters;
using Abp.UI.Inputs;
using FintrakERPIMSDemo.Authorization.Users;
using FintrakERPIMSDemo.CustomInputTypes;

namespace FintrakERPIMSDemo.DynamicEntityParameters
{
    public class AppDynamicEntityParameterDefinitionProvider : DynamicEntityParameterDefinitionProvider
    {
        public override void SetDynamicEntityParameters(IDynamicEntityParameterDefinitionContext context)
        {
            context.Manager.AddAllowedInputType<SingleLineStringInputType>();
            context.Manager.AddAllowedInputType<ComboboxInputType>();
            context.Manager.AddAllowedInputType<CheckboxInputType>();
            context.Manager.AddAllowedInputType<MultiSelectComboboxInputType>();

            //Add entities here 
            context.Manager.AddEntity<User, long>();
        }
    }
}
