using Application.Common.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Delete
{

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandModel>
    {
        private readonly IUserRepo _UserRepo;

        public DeleteUserCommandHandler(IUserRepo UserRepo)
        {
            _UserRepo = UserRepo;
        }

        public async Task Handle(DeleteUserCommandModel request, CancellationToken cancellationToken)
        {
            await _UserRepo.DeleteAsync(await _UserRepo.GetByIdAsync(request.Id));
        }
    }
}
