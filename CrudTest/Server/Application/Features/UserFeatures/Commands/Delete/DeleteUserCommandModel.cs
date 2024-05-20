using MediatR;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Delete
{
    public class DeleteUserCommandModel : IRequest
    {
        public int Id { get; set; }
    }
}

