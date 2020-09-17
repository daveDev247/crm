using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
