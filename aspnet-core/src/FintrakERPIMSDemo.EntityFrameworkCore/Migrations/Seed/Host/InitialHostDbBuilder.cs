using FintrakERPIMSDemo.EntityFrameworkCore;

namespace FintrakERPIMSDemo.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly FintrakERPIMSDemoDbContext _context;

        public InitialHostDbBuilder(FintrakERPIMSDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
