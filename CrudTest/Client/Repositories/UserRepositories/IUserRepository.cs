using Shared.Dtos;
using Shared.Helper;

namespace Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task AddUser(UserDto userData);
        public Task<ResponseData<List<UserDto>>> GetUsers();

    }
}
