using Application.Common.Interfaces;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.FindPersonById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryModel, RoleDto>
    {
        private readonly IRoleRepo _RoleRepo;
        IMapper _mapper;

        public GetRoleByIdQueryHandler(IRoleRepo RoleRepo, IMapper mapper)
        {
            _RoleRepo = RoleRepo;
             _mapper = mapper;


        }

        public async Task<RoleDto> Handle(GetRoleByIdQueryModel request, CancellationToken cancellationToken)
        {
            var cust = await _RoleRepo.GetByIdAsync(request.Id);
            return _mapper.Map<RoleDto>(cust);
        }
    }

}
