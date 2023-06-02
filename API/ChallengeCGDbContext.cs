using API.ModelsConfig;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class ChallengeCGDbContext : DbContext
    {
        public ChallengeCGDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
