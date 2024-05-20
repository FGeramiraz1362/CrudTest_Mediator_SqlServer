using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Shared.Dtos;


namespace Application.Features.CustomerFeatures.Queries.GetCustomersList
{

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryModel, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQueryModel request, CancellationToken cancellationToken)
        {

            var custList = await _customerRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(custList);

        }
    }

}
