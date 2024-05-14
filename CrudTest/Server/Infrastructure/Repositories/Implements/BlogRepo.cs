using Application.Common.Interfaces;
using Infrastructure.Context;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Infrastructure.Repositories.Implements
{
    public class BlogRepo : Repository<Blog>, IBlogRepo
    {
        public BlogRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
