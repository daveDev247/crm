using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace FintrakERPIMSDemo.Net.Emailing
{
    public class FintrakERPIMSDemoSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public FintrakERPIMSDemoSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}