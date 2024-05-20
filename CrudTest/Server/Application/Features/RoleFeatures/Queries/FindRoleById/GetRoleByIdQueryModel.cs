using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.FindPersonById
{
    public class GetRoleByIdQueryModel : IRequest<RoleDto>
    {
        public int Id { get; set; }
    }
}



