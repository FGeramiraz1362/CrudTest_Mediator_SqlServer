using Shared.Helper;

namespace Mc2.CrudTest.Presentation.Client.Repositories
{
    public interface IAuthoRepository
    {
        Task<UserToken> Login(UserInfo userData);

    }
}
