using Client.ViewModels;
using Shared.Dtos;
using System.Net;


namespace Client.ServiceModel;

public interface ICustomerService
{
    Task<CustomerDto[]> GetCustomers();
    Task<CustomerDto> GetCustomerById(int customerId);
    Task<HttpStatusCode> AddCustomer(CustomerCreateInput input);
    Task<HttpStatusCode> UpdateCustomer(int customerId, CustomerUpdateInput input);
    Task<HttpStatusCode> DeleteCustomer(int customerId);
}