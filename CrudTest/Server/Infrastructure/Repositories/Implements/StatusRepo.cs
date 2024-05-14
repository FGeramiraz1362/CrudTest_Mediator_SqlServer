using Application.Common.Interfaces;
using Infrastructure.Context;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Infrastructure.Repositories.Implements
{
    public class StatusRepo : Repository<Status>, IStatusRepo
    {
        public StatusRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
