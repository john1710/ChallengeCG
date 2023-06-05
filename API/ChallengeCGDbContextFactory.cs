using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API
{
    public class ChallengeCGDbContextFactory : IDesignTimeDbContextFactory<ChallengeCGDbContext>
    {
        public ChallengeCGDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChallengeCGDbContext>();
            var connectionString = Environment.GetEnvironmentVariable("ChallengeDB") ?? "Server=sqlserver;Database=challengeDb;User=sa;Password=YourStrong!Passw0rd";
            optionsBuilder.UseSqlServer(connectionString);

            return new ChallengeCGDbContext(optionsBuilder.Options);
        }
    }
}
