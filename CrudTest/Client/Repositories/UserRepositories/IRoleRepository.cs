using Shared.Dtos;
using Shared.Helper;

namespace Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories
{
    public interface IRoleRepository
    {
        public Task<ResponseData<List<RoleDto>>> GetRoles();

    }
}
