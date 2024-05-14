using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(p => p.Id);
          //  builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Family).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.BankAccounNumber).IsRequired();
            builder.HasIndex(v => new { v.Name, v.Family, v.BirthDate }).IsUnique();
            builder.HasIndex(v => new { v.Email}).IsUnique();
           
        }
    }
}
