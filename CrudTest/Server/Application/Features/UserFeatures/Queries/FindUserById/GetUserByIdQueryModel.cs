using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.FindPersonById
{
    public class GetUserByIdQueryModel : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}



