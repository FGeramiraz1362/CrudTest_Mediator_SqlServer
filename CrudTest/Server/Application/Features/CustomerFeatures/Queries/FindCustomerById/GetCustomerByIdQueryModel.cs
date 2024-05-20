using MediatR;
using Shared.Dtos;


namespace Application.Features.CustomerFeatures.Queries.FindCustomerById
{
    public class GetCustomerByIdQueryModel : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}



