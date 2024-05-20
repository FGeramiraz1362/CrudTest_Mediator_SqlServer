using Application.Common.Interfaces;
using FluentValidation;
using PhoneNumbers;

namespace Application.Features.CustomerFeatures.Commands.Add
{
    public class AddCustomerCommandModelValidator : AbstractValidator<AddCustomerCommandModel>
    {
        private readonly IApplicationContext _context;

        public AddCustomerCommandModelValidator(IApplicationContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Family)
               .MaximumLength(200)
               .NotEmpty();

            RuleFor(v => v.Email)
               .MaximumLength(50)
               .NotEmpty();

            RuleFor(v => new { v.Name, v.Family, v.BirthDate })
            .Must(x => BeUniqueNameFamilyBirthDat(x.Name.ToLower(), x.Family.ToLower(), x.BirthDate))
                .WithMessage("Name Family and BirthDate must be unique.")
                .WithErrorCode("Unique");

            RuleFor(v => v.Email.ToLower())
           .Must(BeUniqueEmail)
               .WithMessage("Email Address must be unique.")
               .WithErrorCode("Unique");

            RuleFor(v => new { v.CountryCode, v.MobileNumber })
          .Must(x => MobileNumberMustBeValid(x.CountryCode, x.MobileNumber))
              .WithMessage("MobileNo must be valid.")
              .WithErrorCode("Valid");

        }

        public bool BeUniqueNameFamilyBirthDat(string Name, string Family, DateTime birthDate)
        {
            return
                !_context.Customers.Any(l => l.Name == Name && l.Family == Family && l.BirthDate == birthDate.Date);
        }
        public bool BeUniqueEmail(string Email)
        {
            return _context.Customers
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
