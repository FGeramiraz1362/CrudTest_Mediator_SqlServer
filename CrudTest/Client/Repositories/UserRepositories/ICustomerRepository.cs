using Client.ViewModels;
using Shared.Dtos;
using Shared.Helper;
using System.Net;


namespace Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories;

public interface ICustomerRepository
{
    Task<Tuple<ResponseData<List<CustomerDto>>, int>> GetCustomers(int page, int quantityPerPage, string nameFilter, string familyFilter);
    Task<CustomerDto> GetCustomerById(int customerId);
    Task<HttpStatusCode> AddCustomer(CustomerCreateInput input);
    Task<HttpStatusCode> UpdateCustomer(int customerId, CustomerUpdateInput input);
    Task<HttpStatusCode> DeleteCustomer(int customerId);
}