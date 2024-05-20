using Client.ServiceModel;
using Mc2.CrudTest.Presentation.Client;
using Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories;
using Mc2.CrudTest.Presentation.Client.ServiceModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace Mc2.CrudTest.Presentation.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
         //   builder.Services.AddScoped<IUserAuthService, JWTService>();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            builder.Logging.SetMinimumLevel(LogLevel.Warning);
            builder.Services.AddScoped<AuthRepository>();
            builder.Services.AddScoped<UserStateService>();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<JWTService>();
            builder.Services.AddScoped<AuthenticationStateProvider, JWTService>(
                provider => provider.GetRequiredService<JWTService>());
            builder.Services.AddScoped<IUserAuthService, JWTService>(
                provider => provider.GetRequiredService<JWTService>());


            await builder.Build().RunAsync();
        }
    }
}