using Client.ServiceModel;
using Client.ViewModels;
using Shared.Dtos;
using Shared.Helper;
using System.Net.Http;
using System.Net;

namespace Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpService _httpService;
        private readonly string _UserUrl = "api/user";
        public UserRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<ResponseData<List<UserDto>>> GetUsers()
        {
            var result = await _httpService.GetAsync<List<UserDto>>($"{_UserUrl}");

            return result;
        }

        public async Task AddUser(UserDto userData)
        {
            var response = await _httpService.PutAsync<UserDto>($"{_UserUrl}", userData);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());

            }
        }



    }
}
