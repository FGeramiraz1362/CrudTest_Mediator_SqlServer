using MediatR;
using Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.GetRolsList
{
    public class GetAllRolesQueryModel : IRequest<IEnumerable<RoleDto>>
    {
       
    }
}
