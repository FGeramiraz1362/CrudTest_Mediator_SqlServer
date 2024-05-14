using Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Delete
{

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandModel>
    {
        private readonly ICustomerRepo _customerRepo;

        public DeleteCustomerCommandHandler(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task Handle(DeleteCustomerCommandModel request, CancellationToken cancellationToken)
        {
            await _customerRepo.DeleteAsync(await _customerRepo.GetByIdAsync(request.Id));
        }
    }
}
