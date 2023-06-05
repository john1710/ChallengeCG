// See https://aka.ms/new-console-template for more information
using API;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
var connectionString = Environment.GetEnvironmentVariable("ChallengeDB");
Console.WriteLine($"Variable is {connectionString}");
var optionsBuilder = new DbContextOptionsBuilder<ChallengeCGDbContext>();
if (connectionString is null)
{
    Console.WriteLine("Nao pegou do env");
}
connectionString ??= "Server=sqlserver:1433;Database=challengeDb;User=sa;Password=Admin1234!";
optionsBuilder.UseSqlServer(connectionString);

var context = new ChallengeCGDbContext(optionsBuilder.Options);
context.Database.Migrate();

