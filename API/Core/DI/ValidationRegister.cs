using API.Repositories;
using API.Validations;
using Autofac;

namespace API.Core.DI
{
    public class ValidationRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(AccountValidation).Assembly)
                .Where(p => p.Name.EndsWith("Validation"))
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
