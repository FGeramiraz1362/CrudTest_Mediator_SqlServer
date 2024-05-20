using MediatR;
using Shared.Dtos;
using Shared.Helper;


namespace Application.Features.CustomerFeatures.Queries.FindCustomerByFilter
{
    public class GetCustomerByFilterQueryModel : IRequest<Tuple<IEnumerable<CustomerDto>, int>>
    {
        public PaginationDTO PaginationDTO { get; set; }
        public CustomerFilterDto CustomerFilterDto { get; set; }
    }
}



