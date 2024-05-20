using Shared.Helper;


namespace Client.ServiceModel;

public interface IHttpService
{
    public  Task<ResponseData<Object>> PostAsync<T>(string url, T data);
    public  Task<ResponseData<TResponse>> PostAsync<T, TResponse>(string url, T data);
    public Task<ResponseData<TResponse>> GetAsync<TResponse>(string url);
    Task<ResponseData<object>> PutAsync<T>(string url, T data);
    Task<ResponseData<TResponse>> PutAsync<T, TResponse>(string url, T data);
    Task<Tuple<ResponseData<TResponse>, int>> GetAsyncByPaging<TResponse>(string url);
}