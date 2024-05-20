using Application.Common.Interfaces;
using FluentValidation;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Edit
{
    public class EditUserCommandModelValidator : AbstractValidator<EditUserCommandModel>
    {
        private readonly IApplicationContext _context;

        public EditUserCommandModelValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.LastName)
               .MaximumLength(200)
               .NotEmpty();

            RuleFor(v => v.Email)
               .MaximumLength(50)
               .NotEmpty();


            RuleFor(v => new { v.Name, v.LastName ,v.Id})
            .Must(x => BeUniqueNameFamily(x.Name.ToLower(), x.LastName.ToLower(),x.Id))
                .WithMessage("Name Family must be unique.")
                .WithErrorCode("Unique");

            RuleFor(v => new { v.Email, v.Id })
           .Must(x => BeUniqueEmail(x.Email,x.Id))
               .WithMessage("Email Address must be unique.")
               .WithErrorCode("Unique");

           

        }

        public bool BeUniqueNameFamily(string Name, string lastName, int id)
        {
            return
                !_context.Users.Any(l => (l.Name == Name && l.LastName == lastName  && l.Id!= id));
        }
        public bool BeUniqueEmail(string Email, int id )
        {
            return _context.Users
                .All(l => l.Email != Email.ToLower() || l.Id== id);
        }

       

    }
}
