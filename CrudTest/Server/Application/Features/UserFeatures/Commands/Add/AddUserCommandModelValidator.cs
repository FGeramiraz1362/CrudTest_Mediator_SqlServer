using Application.Common.Interfaces;
using FluentValidation;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Add
{
    public class AddUserCommandModelValidator : AbstractValidator<AddUserCommandModel>
    {
        private readonly IApplicationContext _context;

        public AddUserCommandModelValidator(IApplicationContext context)
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

            RuleFor(v => new { v.Name, v.LastName})
            .Must(x => BeUniqueNameFamily(x.Name.ToLower(), x.LastName.ToLower()))
                .WithMessage("Name Family and BirthDate must be unique.")
                .WithErrorCode("Unique");

            RuleFor(v => v.Email.ToLower())
           .Must(BeUniqueEmail)
               .WithMessage("Email Address must be unique.")
               .WithErrorCode("Unique");

        }

        public bool BeUniqueNameFamily(string Name, string Family)
        {
            return
                !_context.Users.Any(l => (l.Name == Name && l.LastName == Family ));
        }
        public bool BeUniqueEmail(string Email)
        {
            return _context.Users
                .All(l => l.Email != Email);
        }

        public bool MobileNumberMustBeValid(uint CountryCode, ulong MobileNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            var phoneNumber = phoneNumberUtil.Parse(string.Concat("+", CountryCode, " ", MobileNumber), null);
            PhoneNumberType phoneNumberType = phoneNumberUtil.GetNumberType(phoneNumber);
            if (phoneNumberType != PhoneNumberType.MOBILE) return false;

            if (!phoneNumberUtil.IsPossibleNumber(phoneNumber))
                return false;

            return true;

        }

    }
}
