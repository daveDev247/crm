using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using FintrakERPIMSDemo.Authentication.TwoFactor.Google;
using FintrakERPIMSDemo.Authorization;
using FintrakERPIMSDemo.Authorization.Roles;
using FintrakERPIMSDemo.Authorization.Users;
using FintrakERPIMSDemo.Editions;
using FintrakERPIMSDemo.MultiTenancy;

namespace FintrakERPIMSDemo.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
