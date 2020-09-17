using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FintrakERPIMSDemo.EntityFrameworkCore
{
    public static class FintrakERPIMSDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FintrakERPIMSDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FintrakERPIMSDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}