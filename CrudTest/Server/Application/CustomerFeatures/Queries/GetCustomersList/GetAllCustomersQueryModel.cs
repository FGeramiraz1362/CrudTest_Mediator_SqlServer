using MediatR;
using Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Queries.GetPersonsList
{
    public class GetAllCustomersQueryModel : IRequest<IEnumerable<CustomerDto>>
    {
       
    }
}
