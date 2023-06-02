using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.ModelsConfig
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);

            builder.HasData(GetSeededData());
        }


        private Account[] GetSeededData()
        {
            return new Account[]
            {
                new Account("John Doe", "Some random description"){Id=-1},
                new Account("Jane Doe", "Some random description to Jane"){ Id=-2}
            };
        }
    }
}
