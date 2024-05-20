namespace Shared.Helper
{
    public class ResponseData<T>
    {
        public T Response { get; set;}
        public bool Success { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public ResponseData(T response, bool success , HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Success = success;
            HttpResponseMessage = httpResponseMessage;
        }
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
