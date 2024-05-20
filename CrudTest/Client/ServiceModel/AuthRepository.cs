using Client.ServiceModel;
using Shared.Helper;

namespace Mc2.CrudTest.Presentation.Client.ServiceModel
{
    public class AuthRepository
    {
        private readonly IHttpService _httpService;
        public AuthRepository(IHttpService httpService)
        {
            _httpService = httpService;

        }
        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var url = $"/api/accounts/login";
            ResponseData<UserToken> response = await _httpService.PostAsync<UserInfo, UserToken>(url, userInfo);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
    }
}
