using API.Repositories;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace API.Core.DI
{
    public class RepositoryRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(p =>
            {
                var config = p.Resolve<IConfiguration>();
                var opt = new DbContextOptionsBuilder<ChallengeCGDbContext>();
                var connectionString = config.GetConnectionString("ChallengeCGDataBase");
                opt.UseSqlServer(connectionString);
                return new ChallengeCGDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(AccountRepository).Assembly)
                .Where(p => p.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
