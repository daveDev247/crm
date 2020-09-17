using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FintrakERPIMSDemo.Configuration;
using FintrakERPIMSDemo.Web;

namespace FintrakERPIMSDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FintrakERPIMSDemoDbContextFactory : IDesignTimeDbContextFactory<FintrakERPIMSDemoDbContext>
    {
        public FintrakERPIMSDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FintrakERPIMSDemoDbContext>();
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            FintrakERPIMSDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FintrakERPIMSDemoConsts.ConnectionStringName));

            return new FintrakERPIMSDemoDbContext(builder.Options);
        }
    }
}