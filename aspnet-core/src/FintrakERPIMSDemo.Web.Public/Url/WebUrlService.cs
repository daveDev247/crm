using Abp.Dependency;
using FintrakERPIMSDemo.Configuration;
using FintrakERPIMSDemo.Url;
using FintrakERPIMSDemo.Web.Url;

namespace FintrakERPIMSDemo.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}