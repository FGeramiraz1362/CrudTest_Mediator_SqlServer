using Client.ViewModels;
using Shared.Dtos;
using System.Net;
using System.Net.Http.Json;
using static MudBlazor.Icons;
using static System.Net.WebRequestMethods;


namespace Client.ServiceModel;

public class CustomerService : ICustomerService
{
	private readonly HttpClient _httpClient;

	public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;

	}
  
    public async Task<CustomerDto[]> GetCustomers()
    {
		Console.WriteLine("geere");
		return await _httpClient.GetFromJsonAsync<CustomerDto[]>("customer");

    }

    public async Task<CustomerDto> GetCustomerById(int customerId)
    {
        var url = $"/customer/{customerId}";
        return( await _httpClient.GetFromJsonAsync<CustomerDto>(url));

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
		var response  = await _httpClient.DeleteAsync(url);
        return response.StatusCode;
    }
}