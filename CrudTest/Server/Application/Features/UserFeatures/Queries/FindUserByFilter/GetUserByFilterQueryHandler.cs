using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.FindPersonById
{
    public class GetUserByFilterQueryHandler : IRequestHandler<GetUserByFilterQueryModel, IEnumerable<UserDto>>
    {
        private readonly IUserRepo _UserRepo;
        IMapper _mapper;

        public GetUserByFilterQueryHandler(IUserRepo UserRepo, IMapper mapper)
        {
            _UserRepo = UserRepo;
            _mapper = mapper;


        }

        public async Task<IEnumerable<UserDto>> Handle(GetUserByFilterQueryModel request, CancellationToken cancellationToken)
        {
            var custList = await _UserRepo.GetUsersByFiletr(request.PaginationDTO, request.UserFilterDto);
            return _mapper.Map<IEnumerable<UserDto>>(custList);
        }
    }
}


