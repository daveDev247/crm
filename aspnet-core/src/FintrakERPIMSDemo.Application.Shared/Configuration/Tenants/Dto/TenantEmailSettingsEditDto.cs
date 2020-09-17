using Abp.Auditing;
using FintrakERPIMSDemo.Configuration.Dto;

namespace FintrakERPIMSDemo.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}