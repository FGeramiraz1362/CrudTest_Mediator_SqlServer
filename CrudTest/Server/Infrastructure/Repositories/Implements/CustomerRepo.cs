using Infrastructure.Context;
using Infrastructure.Helper;
using Infrastructure.Repositories.Interfaces;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;
using System.Net.Http;

namespace Infrastructure.Repositories.Implements
{
    public class CustomerRepo : Repository<CustomerEntity>, ICustomerRepo
    {
        ApplicationContext _context;
        public CustomerRepo(ApplicationContext context) : base(context)
        {
            _context= context;
        }
        public async Task<Tuple<List<CustomerEntity>, int>> GetCustomersByFiletr(PaginationDTO pagination, CustomerFilterDto customerFilterDto)
        {
            var queryable = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(customerFilterDto.Name))
                queryable= queryable. Where(t => t.Name == customerFilterDto.Name);

            if (!string.IsNullOrEmpty(customerFilterDto.Family))
                queryable = queryable.Where(t => t.Family == customerFilterDto.Family);

            return  new Tuple<List<CustomerEntity>, int> (await queryable.Paginate(pagination).OrderBy(t=>t.Id).ToListAsync(),await queryable.CountAsync());

        }

    }
}
