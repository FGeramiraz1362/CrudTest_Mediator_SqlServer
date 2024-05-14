using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces
{
    public interface IApplicationContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        Task<int> SaveChangesAsync();
    }
}