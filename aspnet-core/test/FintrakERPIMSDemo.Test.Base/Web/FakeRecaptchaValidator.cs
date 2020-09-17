using System.Threading.Tasks;
using FintrakERPIMSDemo.Security.Recaptcha;

namespace FintrakERPIMSDemo.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
