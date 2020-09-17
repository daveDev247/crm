using Microsoft.Extensions.Configuration;

namespace FintrakERPIMSDemo.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
