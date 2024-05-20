using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync();
    }
}