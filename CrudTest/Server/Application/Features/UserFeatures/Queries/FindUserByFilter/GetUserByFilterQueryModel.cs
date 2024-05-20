using MediatR;
using Shared.Dtos;
using Shared.Helper;


namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.FindPersonById
{
    public class GetUserByFilterQueryModel : IRequest<IEnumerable<UserDto>>
    {
        public PaginationDTO PaginationDTO { get; set; }
        public UserFilterDto UserFilterDto { get; set; }
    }
}



