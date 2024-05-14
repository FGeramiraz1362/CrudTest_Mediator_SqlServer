using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Queries.GetPersonsList
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


            //return _mapper.Map<Customer>(cust);

            //return await _context.Customers
            //   .AsNoTracking()
            //   .ProjectTo<Customer>(_mapper.ConfigurationProvider)
            //   .OrderBy(t => t.Name)
            //   .ToListAsync(cancellationToken);
    
        }
    }

}
