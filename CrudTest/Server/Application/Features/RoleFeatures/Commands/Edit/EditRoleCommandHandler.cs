using Application.Common.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Edit
{
    public class EditRoleCommandModel : IRequest
    {
        public int Id { get; set; }
        [Required]
        public string FnCaption { get; set; }
        [Required]
        public string EnCaption { get; set; }

    }
    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommandModel>
    {
        private readonly IRoleRepo _RoleRepo;

        public EditRoleCommandHandler(IRoleRepo RoleRepo)
        {
            _RoleRepo = RoleRepo;
        }

        public async Task Handle(EditRoleCommandModel request, CancellationToken cancellationToken)
        {
            var Role = await _RoleRepo.GetByIdAsync(request.Id);

            if (Role != null)
            {
                Role.FnCaption = request.FnCaption;
                Role.EnCaption = request.EnCaption;
               
                await _RoleRepo.UpdateAsync(Role);
            }
        }
    }
}
