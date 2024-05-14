using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Edit
{
    public class EditCustomerCommandModel : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime BirthDate { get; set; }
        public ulong MobileNumber { get; set; }
        public uint CountryCode { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommandModel>
    {
        private readonly ICustomerRepo _customerRepo;

        public EditCustomerCommandHandler(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task Handle(EditCustomerCommandModel request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepo.GetByIdAsync(request.Id);

            if (customer != null)
            {
                customer.Name = request.Name;
                customer.Family = request.Family;
                customer.BirthDate = request.BirthDate.Date;
                customer.PhoneNumebr = new Models.CustomerEntity.PhoneNumebrEntity
                {
                    MobileNumber = request.MobileNumber,
                    CountryCode = request.CountryCode
                };
                customer.Email = request.Email;

                await _customerRepo.UpdateAsync(customer);
            }
        }
    }
}
