using Application.Common.Interfaces;
using FluentValidation;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Add
{
    public class AddRoleCommandModelValidator : AbstractValidator<AddRoleCommandModel>
    {
        private readonly IApplicationContext _context;

        public AddRoleCommandModelValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(v => v.FnCaption)
                .MaximumLength(1000)
                .NotEmpty();

            RuleFor(v => v.EnCaption)
               .MaximumLength(1000)
               .NotEmpty();

        }
    }
}
