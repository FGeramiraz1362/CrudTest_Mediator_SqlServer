using Application.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Edit
{
    public class EditUserCommandModel : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public int RoleId {  get; set; }

        public string Password { get; set; }

    }
    public class EditUserCommandHandler : IRequestHandler<EditUserCommandModel>
    {
        private readonly IUserRepo _UserRepo;

        public EditUserCommandHandler(IUserRepo UserRepo)
        {
            _UserRepo = UserRepo;
        }

        public async Task Handle(EditUserCommandModel request, CancellationToken cancellationToken)
        {
            var User = await _UserRepo.GetByIdAsync(request.Id);

            if (User != null)
            {
                User.Name = request.Name;
                User.LastName = request.LastName;
                User.Job = request.Job;
                User.RoleId = request.RoleId;
                User.Email = request.Email;

                await _UserRepo.UpdateAsync(User);
            }
        }
    }
}
