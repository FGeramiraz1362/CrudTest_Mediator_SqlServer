using Application.Common.Interfaces;
using FluentValidation;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Add
{
    public class AddRoleCommandModel : IRequest<int>
    {
        public string EnCaption { get; set; }
        public string FnCaption { get; set; }
        
    }

    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommandModel, int>
    {
        private readonly IRoleRepo _RoleRepo;
        private readonly IValidator<AddRoleCommandModel> _validator;

        public AddRoleCommandHandler(IRoleRepo RoleRepo)
        {
            _RoleRepo = RoleRepo;

        }

        public async Task<int> Handle(AddRoleCommandModel request, CancellationToken cancellationToken)
        {
            var Role = new Role
            {
                EnCaption = request.EnCaption,
                FnCaption = request.FnCaption,

            };
            await _RoleRepo.AddAsync(Role);
            return Role.Id;
        }
    }
}
