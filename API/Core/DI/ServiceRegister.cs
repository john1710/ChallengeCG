using API.Repositories;
using API.Services;
using Autofac;

namespace API.Core.DI
{
    public class ServiceRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
                .Where(p => p.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
