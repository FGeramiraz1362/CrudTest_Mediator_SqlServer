using Shared.Helper;
using System.Text;
using System.Text.Json;


namespace Client.ServiceModel;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    private JsonSerializerOptions defualJsonSerializerOptions => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };


    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }

    public async Task<ResponseData<Object>> PostAsync<T>(string url, T data)
    {
        var dataSerialize = JsonSerializer.Serialize(data);
        var contetnt = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, contetnt);
        return new ResponseData<object>(null, response.IsSuccessStatusCode, response);

    }
    public async Task<ResponseData<TResponse>> PostAsync<T, TResponse>(string url, T data)
    {
        var dataSerialize = JsonSerializer.Serialize(data);
        var contetnt = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, contetnt);
        if (response.IsSuccessStatusCode)
        {
            var responseDesrilaized = await Deserialize<TResponse>(response, defualJsonSerializerOptions);
            return new ResponseData<TResponse>(responseDesrilaized, true, response);
        }
        else
        {
            return new ResponseData<TResponse>(default, false, response);
        }

    }

    public async Task<ResponseData<TResponse>> GetAsync< TResponse>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseDesrilaized = await Deserialize<TResponse>(response, defualJsonSerializerOptions);
            return new ResponseData<TResponse>(responseDesrilaized, true, response);
        }
        else
        {
            return new ResponseData<TResponse>(default, false, response);
        }

    }

    public async Task<Tuple<ResponseData<TResponse>, int>> GetAsyncByPaging<TResponse>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var totalPageQuantity = int.Parse(response.Headers.GetValues("pagesQuantity").FirstOrDefault());

           
            var responseDesrilaized = await Deserialize<TResponse>(response, defualJsonSerializerOptions);
            return new Tuple<ResponseData<TResponse>, int> (new ResponseData<TResponse>(responseDesrilaized, true, response), totalPageQuantity);
        }
        else
        {
            return new Tuple<ResponseData<TResponse>, int> (new ResponseData<TResponse>(default, false, response), 0);
        }

    }

    public async Task<ResponseData<Object>> PutAsync<T>(string url, T data)
    {
        var dataSerialize = JsonSerializer.Serialize(data);
        var contetnt = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(url, contetnt);
        return new ResponseData<object>(null, response.IsSuccessStatusCode, response);

    }
    public async Task<ResponseData<TResponse>> PutAsync<T, TResponse>(string url, T data)
    {
        var dataSerialize = JsonSerializer.Serialize(data);
        var contetnt = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(url, contetnt);
        if (response.IsSuccessStatusCode)
        {
            var responseDesrilaized = await Deserialize<TResponse>(response, defualJsonSerializerOptions);
            return new ResponseData<TResponse>(responseDesrilaized, true, response);
        }
        else
        {
            return new ResponseData<TResponse>(default, false, response);
        }

    }


    private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
    {
        var responseString = await httpResponse.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseString, options);

    }

}