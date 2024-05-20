using Application.Common.Interfaces;
using AutoMapper;
using Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.GetRolsList;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.GetRolesList
{

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryModel, IEnumerable<RoleDto>>
    {
        private readonly IRoleRepo _RoleRepo;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IRoleRepo RoleRepo, IMapper mapper)
        {
            _RoleRepo = RoleRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQueryModel request, CancellationToken cancellationToken)
        {

            var custList = await _RoleRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(custList);
    
        }
    }

}
