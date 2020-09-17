using Abp.Events.Bus;

namespace FintrakERPIMSDemo.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}