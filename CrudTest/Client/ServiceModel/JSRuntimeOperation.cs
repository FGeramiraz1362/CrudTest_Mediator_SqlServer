using Microsoft.JSInterop;

namespace Mc2.CrudTest.Presentation.Client.ServiceModel
{
    public static class JSRuntimeOperation
    {
        public static ValueTask<object> SetItem(this IJSRuntime js , string key , string value  )
        {
            return js.InvokeAsync<object>("localStorage.setItem", key, value);
        }
        public static ValueTask<string> GetItem(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<string>("localStorage.getItem", key);
        }
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }
    }
}
