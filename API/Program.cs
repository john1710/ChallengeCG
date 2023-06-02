using API.Core.DI;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
builder.Services.AddControllers();

//DI containers
var modules = new List<IModule> {
    new ServiceRegister(),
    new RepositoryRegister(),
    new ValidationRegister()
};

builder.Host.ConfigureContainer<ContainerBuilder>(builderContainer => modules.ForEach(module => builderContainer.RegisterModule(module)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
