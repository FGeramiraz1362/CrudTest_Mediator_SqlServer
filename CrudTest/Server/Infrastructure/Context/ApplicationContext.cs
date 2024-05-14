
using Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Contraints

            modelBuilder.Entity<CustomerEntity>().HasIndex(t => t.Email).IsUnique();
            modelBuilder.Entity<CustomerEntity>().HasIndex(t => new { t.Name, t.Family, t.Email }).IsUnique();
            modelBuilder.Entity<CustomerEntity>()
                    .Property(e => e.BirthDate)
                    .HasColumnType("date");

            #endregion
        }
    }
}
