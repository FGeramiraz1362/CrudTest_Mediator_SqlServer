using MediatR;
using Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.GetUsersList
{
    public class GetAllUsersQueryModel : IRequest<IEnumerable<UserDto>>
    {
       
    }
}
