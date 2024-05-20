using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.GetUsersList
{

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryModel, IEnumerable<UserDto>>
    {
        private readonly IUserRepo _UserRepo;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepo UserRepo, IMapper mapper)
        {
            _UserRepo = UserRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQueryModel request, CancellationToken cancellationToken)
        {

            var custList = await _UserRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(custList);
    
        }
    }

}
