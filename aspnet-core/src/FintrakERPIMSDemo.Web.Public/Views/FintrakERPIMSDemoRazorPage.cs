using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace FintrakERPIMSDemo.Web.Public.Views
{
    public abstract class FintrakERPIMSDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected FintrakERPIMSDemoRazorPage()
        {
            LocalizationSourceName = FintrakERPIMSDemoConsts.LocalizationSourceName;
        }
    }
}
