using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using FintrakERPIMSDemo.Authorization.Users;
using FintrakERPIMSDemo.MultiTenancy;

namespace FintrakERPIMSDemo.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}