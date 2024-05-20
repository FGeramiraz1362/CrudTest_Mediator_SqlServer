
using Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationContext : IdentityDbContext, IApplicationContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuss { get; set; }



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

            modelBuilder.Entity<User>().
                HasOne(t => t.Role).WithMany(t => t.Users).HasForeignKey(t => t.RoleId);


            #endregion
        }
    }
}
