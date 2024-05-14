using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Infrastructure.Repositories.Implements
{
    public class CustomerRepo : Repository<CustomerEntity>, ICustomerRepo
    {
        public CustomerRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
