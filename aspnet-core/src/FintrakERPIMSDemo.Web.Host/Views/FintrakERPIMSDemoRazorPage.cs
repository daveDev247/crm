using Abp.AspNetCore.Mvc.Views;

namespace FintrakERPIMSDemo.Web.Views
{
    public abstract class FintrakERPIMSDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected FintrakERPIMSDemoRazorPage()
        {
            LocalizationSourceName = FintrakERPIMSDemoConsts.LocalizationSourceName;
        }
    }
}
