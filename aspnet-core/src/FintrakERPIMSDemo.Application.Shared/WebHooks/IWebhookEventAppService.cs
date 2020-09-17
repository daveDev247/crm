using System.Threading.Tasks;
using Abp.Webhooks;

namespace FintrakERPIMSDemo.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
