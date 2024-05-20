using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text.Json;

namespace Mc2.CrudTest.Presentation.Client.ServiceModel
{
    public class JWTService: AuthenticationStateProvider, IUserAuthService
    {
        private readonly IJSRuntime js;
        private static readonly string TOKENKEY = "TOKENKEY";
        private UserStateService _userStateService;

        private AuthenticationState EmptyUserData => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        private readonly HttpClient httpClient;
        
       
        public JWTService(IJSRuntime jsRunTime, HttpClient http, UserStateService userStateService)
        {
            js = jsRunTime;
            httpClient = http;
            _userStateService = userStateService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await js.GetItem(TOKENKEY);

            if (string.IsNullOrEmpty(token))
            {
                return EmptyUserData;
            }

            return BuildAuthenticationState(token);
        }
        private AuthenticationState BuildAuthenticationState(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }


        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
        public async Task Login(string token)
        {
            await js.SetItem(TOKENKEY, token);
            var authState = BuildAuthenticationState(token);

            _userStateService.SetUserInfo(authState.User.Claims);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            httpClient.DefaultRequestHeaders.Authorization = null;
            await js.RemoveItem(TOKENKEY);
            NotifyAuthenticationStateChanged(Task.FromResult(EmptyUserData));
        }
        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

    }
}
