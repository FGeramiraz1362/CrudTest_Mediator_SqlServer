using MediatR;
using Shared.Dtos;

namespace Application.Features.CustomerFeatures.Queries.GetCustomersList
{
    public class GetAllCustomersQueryModel : IRequest<IEnumerable<CustomerDto>>
    {

    }
}
