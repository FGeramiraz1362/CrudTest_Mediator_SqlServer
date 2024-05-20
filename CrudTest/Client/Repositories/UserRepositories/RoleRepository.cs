using Client.ServiceModel;
using Shared.Dtos;
using Shared.Helper;

namespace Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IHttpService _httpService;
        private readonly string _roleUrl = "api/role";
        public RoleRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<ResponseData<List<RoleDto>>> GetRoles()
        {
            var result = await _httpService.GetAsync<List<RoleDto>>($"{_roleUrl}");

            return result;
        }

    }
}
