using Application.Common.Interfaces;
using FluentValidation;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Edit
{
    public class EditCustomerCommandModelValidator : AbstractValidator<EditCustomerCommandModel>
    {
        private readonly IApplicationContext _context;

        public EditCustomerCommandModelValidator(IApplicationContext context)
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

            RuleFor(v => v.BankAccountNumber)
               .MaximumLength(100)
               .NotEmpty();


            RuleFor(v => v.BirthDate)
              .NotEmpty()
              .WithMessage("BirthDate should has value.");

            RuleFor(v => v.BirthDate)
               .GreaterThan(DateTime.MinValue.Date)
               .WithMessage("BirthDate should has value.");

            RuleFor(v => new { v.Name, v.Family, v.BirthDate ,v.Id})
            .Must(x => BeUniqueNameFamilyBirthDat(x.Name.ToLower(), x.Family.ToLower(), x.BirthDate,x.Id))
                .WithMessage("Name Family and BirthDate must be unique.")
                .WithErrorCode("Unique");

            RuleFor(v => new { v.Email, v.Id })
           .Must(x => BeUniqueEmail(x.Email,x.Id))
               .WithMessage("Email Address must be unique.")
               .WithErrorCode("Unique");

            RuleFor(v => new { v.CountryCode, v.MobileNumber })
          .Must(x => MobileNumberMustBeValid(x.CountryCode, x.MobileNumber))
              .WithMessage("MobileNo must be valid.")
              .WithErrorCode("Valid");

        }

        public bool BeUniqueNameFamilyBirthDat(string Name, string Family, DateTime birthDate, int id)
        {
            return
                !_context.Customers.Any(l => (l.Name == Name && l.Family == Family && l.BirthDate == birthDate.Date && l.Id!= id));
        }
        public bool BeUniqueEmail(string Email, int id )
        {
            return _context.Customers
                .All(l => l.Email != Email.ToLower() || l.Id== id);
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
