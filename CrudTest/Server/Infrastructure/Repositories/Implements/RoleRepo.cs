using Application.Common.Interfaces;
using Infrastructure.Context;
using Infrastructure.Helper;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;

namespace Infrastructure.Repositories.Implements
{
    public class RoleRepo : Repository<Role>, IRoleRepo
    {
        ApplicationContext _context;
        public RoleRepo(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetRolesByFiletr(PaginationDTO pagination, RoleFilterDto RoleFilterDto)
        {
            var queryable = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(RoleFilterDto.EnCaption))
                queryable = queryable.Where(t => t.EnCaption == RoleFilterDto.EnCaption);

            if (!string.IsNullOrEmpty(RoleFilterDto.FnCaption))
                queryable = queryable.Where(t => t.FnCaption == RoleFilterDto.FnCaption);

            return await queryable.Paginate(pagination).ToListAsync();

        }
    }
}
