using MediatR;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Delete
{
    public class DeleteRoleCommandModel : IRequest
    {
        public int Id { get; set; }
    }
}

