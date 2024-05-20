using Domain.Common;
using Mc2.CrudTest.Presentation.Server.Models;
using Shared.Helper;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepo : IRepository<CustomerEntity>
    {
        public Task<Tuple<List<CustomerEntity>, int>> GetCustomersByFiletr(PaginationDTO pagination, CustomerFilterDto customerFilterDto);

    }
}
