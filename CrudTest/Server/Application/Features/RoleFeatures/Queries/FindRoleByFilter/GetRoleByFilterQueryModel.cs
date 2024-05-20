using MediatR;
using Shared.Dtos;
using Shared.Helper;


namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.FindPersonById
{
    public class GetRoleByFilterQueryModel : IRequest<IEnumerable<RoleDto>>
    {
        public PaginationDTO PaginationDTO { get; set; }
        public RoleFilterDto RoleFilterDto { get; set; }
    }
}



