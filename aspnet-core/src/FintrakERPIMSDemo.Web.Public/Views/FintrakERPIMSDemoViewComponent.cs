using Abp.AspNetCore.Mvc.ViewComponents;

namespace FintrakERPIMSDemo.Web.Public.Views
{
    public abstract class FintrakERPIMSDemoViewComponent : AbpViewComponent
    {
        protected FintrakERPIMSDemoViewComponent()
        {
            LocalizationSourceName = FintrakERPIMSDemoConsts.LocalizationSourceName;
        }
    }
}