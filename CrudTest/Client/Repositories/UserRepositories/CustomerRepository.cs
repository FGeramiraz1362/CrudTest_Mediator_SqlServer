using Client.ServiceModel;
using Client.ViewModels;
using Shared.Dtos;
using Shared.Helper;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using static MudBlazor.Icons;
using static System.Net.WebRequestMethods;


namespace Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly HttpClient _httpClient;

    private readonly IHttpService _httpService;
    private readonly string _customerUrl = "customer";
    public CustomerRepository(IHttpService httpService)
    {
        _httpService = httpService;
    }

   
    public async Task<Tuple<ResponseData<List<CustomerDto>>, int>> GetCustomers(int page , int quantityPerPage, string nameFilter, string familyFilter)
    {
        var filter = new StringBuilder($"customer?page={page}&quantityPerPage={quantityPerPage}");

        if (!string.IsNullOrEmpty(nameFilter))
            filter.Append($"&name={nameFilter}");

        if (!string.IsNullOrEmpty(familyFilter))
            filter.Append($"&family={familyFilter}");

        var result = await _httpService.GetAsyncByPaging<List<CustomerDto>>(filter.ToString());

        return result;
    }

    public async Task<CustomerDto> GetCustomerById(int customerId)
    {
        var url = $"/customer/{customerId}";
        return await _httpClient.GetFromJsonAsync<CustomerDto>(url);

    }

    public async Task<HttpStatusCode> AddCustomer(CustomerCreateInput customer)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync("customer", new CustomerDto
        {
            Name = customer.Name,
            Family = customer.Family,
            BirthDate = customer.BirthDate != null ? customer.BirthDate : DateTime.MinValue,
            Email = customer.Email,
            BankAccounNumber = customer.BankAccounNumber,
            CountryCode = customer.CountryCode,
            MobileNumber = customer.MobileNumber

        }
            );

        HttpStatusCode resCode = response.StatusCode;

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> UpdateCustomer(int customerId, CustomerUpdateInput customer)
    {
        var url = $"/customer/{customerId}";
        var response = await _httpClient.PutAsJsonAsync(url, customer);

        response.EnsureSuccessStatusCode();
        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteCustomer(int customerId)
    {
        var url = $"/customer/{customerId}";
        var response = await _httpClient.DeleteAsync(url);
        return response.StatusCode;
    }
}