using Application.Common.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Delete
{

    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandModel>
    {
        private readonly IRoleRepo _RoleRepo;

        public DeleteRoleCommandHandler(IRoleRepo RoleRepo)
        {
            _RoleRepo = RoleRepo;
        }

        public async Task Handle(DeleteRoleCommandModel request, CancellationToken cancellationToken)
        {
            await _RoleRepo.DeleteAsync(await _RoleRepo.GetByIdAsync(request.Id));
        }
    }
}
