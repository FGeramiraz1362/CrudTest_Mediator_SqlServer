using Client.ServiceModel;
using Shared;
using Shared.Helper;
using System.ComponentModel.Design;

namespace Mc2.CrudTest.Presentation.Client.Repositories
{
    public class AuthoRepository : IAuthoRepository
    {
        private readonly IHttpService _httpService;
        private readonly string authUrl ="api/auth";

        public AuthoRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<UserToken> Login(UserInfo userData)
        {
            var response = await _httpService.PostAsync<UserInfo, UserToken>($"{authUrl}/login", userData);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());

            }
            return response.Response;
        }
    }
}
