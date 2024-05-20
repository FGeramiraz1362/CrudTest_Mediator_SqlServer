using Domain.Common;
using Mc2.CrudTest.Presentation.Server.Models;
using Shared.Helper;

namespace Application.Common.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        public Task<List<User>> GetUsersByFiletr(PaginationDTO pagination, UserFilterDto UserFilterDto);

    }
}
