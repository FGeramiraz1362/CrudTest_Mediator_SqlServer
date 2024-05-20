using Application.Common.Interfaces;
using Infrastructure.Context;
using Infrastructure.Helper;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;

namespace Infrastructure.Repositories.Implements
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        ApplicationContext _context;
        public UserRepo(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersByFiletr(PaginationDTO pagination, UserFilterDto UserFilterDto)
        {
            var queryable = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(UserFilterDto.Name))
                queryable = queryable.Where(t => t.Name == UserFilterDto.Name);

            if (!string.IsNullOrEmpty(UserFilterDto.LastName))
                queryable = queryable.Where(t => t.LastName == UserFilterDto.LastName);

            return await queryable.Paginate(pagination).ToListAsync();

        }
    }
}
