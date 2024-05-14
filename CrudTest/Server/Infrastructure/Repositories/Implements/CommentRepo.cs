using Application.Common.Interfaces;
using Infrastructure.Context;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Infrastructure.Repositories.Implements
{
    public class CommentRepo : Repository<Comment>, ICommentRepo
    {
        public CommentRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
