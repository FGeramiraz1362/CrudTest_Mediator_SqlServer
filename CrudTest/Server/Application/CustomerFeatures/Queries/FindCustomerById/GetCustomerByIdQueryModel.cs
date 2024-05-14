using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Queries.FindPersonById
{
    public class GetCustomerByIdQueryModel : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}



