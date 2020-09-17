using System.Threading.Tasks;
using FintrakERPIMSDemo.Authorization.Users;

namespace FintrakERPIMSDemo.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
