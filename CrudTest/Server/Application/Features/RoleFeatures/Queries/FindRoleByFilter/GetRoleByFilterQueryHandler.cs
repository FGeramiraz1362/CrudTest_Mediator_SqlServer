using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.RoleFeatures.Queries.FindPersonById
{
    public class GetRoleByFilterQueryHandler : IRequestHandler<GetRoleByFilterQueryModel, IEnumerable<RoleDto>>
    {
        private readonly IRoleRepo _RoleRepo;
        IMapper _mapper;

        public GetRoleByFilterQueryHandler(IRoleRepo RoleRepo, IMapper mapper)
        {
            _RoleRepo = RoleRepo;
            _mapper = mapper;


        }

        public async Task<IEnumerable<RoleDto>> Handle(GetRoleByFilterQueryModel request, CancellationToken cancellationToken)
        {
            var custList = await _RoleRepo.GetRolesByFiletr(request.PaginationDTO, request.RoleFilterDto);
            return _mapper.Map<IEnumerable<RoleDto>>(custList);
        }
    }
}


