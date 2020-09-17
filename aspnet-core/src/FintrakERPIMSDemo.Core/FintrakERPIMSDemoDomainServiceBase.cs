using Abp.Domain.Services;

namespace FintrakERPIMSDemo
{
    public abstract class FintrakERPIMSDemoDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected FintrakERPIMSDemoDomainServiceBase()
        {
            LocalizationSourceName = FintrakERPIMSDemoConsts.LocalizationSourceName;
        }
    }
}
