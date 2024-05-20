using FluentValidation;
using Infrastructure.Repositories.Interfaces;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Application.Features.CustomerFeatures.Commands.Add
{
    public class AddCustomerCommandModel : IRequest<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime BirthDate { get; set; }
        public ulong MobileNumber { get; set; }
        public uint CountryCode { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandModel, int>
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IValidator<AddCustomerCommandModel> _validator;

        public AddCustomerCommandHandler(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;

        }

        public async Task<int> Handle(AddCustomerCommandModel request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity
            {
                Email = request.Email.ToLower(),
                Family = request.Family.ToLower(),
                PhoneNumebr = new CustomerEntity.PhoneNumebrEntity
                {
                    MobileNumber = request.MobileNumber,
                    CountryCode = request.CountryCode,
                },
                Name = request.Name.ToLower(),
                BirthDate = request.BirthDate,
                BankAccounNumber = request.BankAccountNumber
            };
            await _customerRepo.AddAsync(customer);
            return customer.Id;
        }
    }
}
