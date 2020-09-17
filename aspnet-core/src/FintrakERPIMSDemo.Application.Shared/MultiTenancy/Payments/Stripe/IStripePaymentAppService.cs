using System.Threading.Tasks;
using Abp.Application.Services;
using FintrakERPIMSDemo.MultiTenancy.Payments.Dto;
using FintrakERPIMSDemo.MultiTenancy.Payments.Stripe.Dto;

namespace FintrakERPIMSDemo.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}