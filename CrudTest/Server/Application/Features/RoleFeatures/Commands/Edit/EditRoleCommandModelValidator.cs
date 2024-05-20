using Application.Common.Interfaces;
using FluentValidation;

namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Commands.Edit
{
    public class EditRoleCommandModelValidator : AbstractValidator<EditRoleCommandModel>
    {
        private readonly IApplicationContext _context;

        public EditRoleCommandModelValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(v => v.FnCaption)
                .MaximumLength(10000)
                .NotEmpty();

            RuleFor(v => v.EnCaption)
               .MaximumLength(10000)
               .NotEmpty();

        }


    }
}
