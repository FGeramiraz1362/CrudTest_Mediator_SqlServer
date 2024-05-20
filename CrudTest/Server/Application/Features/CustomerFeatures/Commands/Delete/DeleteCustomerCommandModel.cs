using MediatR;

namespace Application.Features.CustomerFeatures.Commands.Delete
{
    public class DeleteCustomerCommandModel : IRequest
    {
        public int Id { get; set; }
    }
}

