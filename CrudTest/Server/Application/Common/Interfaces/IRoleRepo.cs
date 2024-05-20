using Domain.Common;
using Mc2.CrudTest.Presentation.Server.Models;
using Shared.Helper;

namespace Application.Common.Interfaces
{
    public interface IRoleRepo : IRepository<Role>
    {
        public Task<List<Role>> GetRolesByFiletr(PaginationDTO pagination, RoleFilterDto RoleFilterDto);

    }
}
