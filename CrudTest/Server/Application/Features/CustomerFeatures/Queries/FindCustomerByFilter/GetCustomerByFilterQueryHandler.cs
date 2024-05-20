using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Shared.Dtos;


namespace Application.Features.CustomerFeatures.Queries.FindCustomerByFilter
{
    public class GetCustomerByFilterQueryHandler : IRequestHandler<GetCustomerByFilterQueryModel, Tuple<IEnumerable<CustomerDto>, int>>
    {
        private readonly ICustomerRepo _customerRepo;
        IMapper _mapper;

        public GetCustomerByFilterQueryHandler(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Tuple<IEnumerable<CustomerDto>, int>> Handle(GetCustomerByFilterQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _customerRepo.GetCustomersByFiletr(request.PaginationDTO, request.CustomerFilterDto);

            return new Tuple<IEnumerable<CustomerDto>, int>(_mapper.Map<IEnumerable<CustomerDto>>(result.Item1), result.Item2);
        }
    }
}


