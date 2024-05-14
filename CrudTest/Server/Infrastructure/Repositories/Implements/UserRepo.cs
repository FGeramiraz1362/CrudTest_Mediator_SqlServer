using Application.Common.Interfaces;
using Infrastructure.Context;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Infrastructure.Repositories.Implements
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public UserRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
