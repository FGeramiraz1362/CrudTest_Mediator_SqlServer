using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Shared.Dtos;


namespace Application.Features.CustomerFeatures.Queries.FindCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryModel, CustomerDto>
    {
        private readonly ICustomerRepo _customerRepo;
        IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;


        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQueryModel request, CancellationToken cancellationToken)
        {
            var cust = await _customerRepo.GetByIdAsync(request.Id);
            return _mapper.Map<CustomerDto>(cust);
        }
    }

}
