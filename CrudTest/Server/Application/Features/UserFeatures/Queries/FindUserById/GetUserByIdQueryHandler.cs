using Application.Common.Interfaces;
using AutoMapper;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Shared.Dtos;


namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Queries.FindPersonById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryModel, UserDto>
    {
        private readonly IUserRepo _UserRepo;
        IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepo UserRepo, IMapper mapper)
        {
            _UserRepo = UserRepo;
             _mapper = mapper;


        }

        public async Task<UserDto> Handle(GetUserByIdQueryModel request, CancellationToken cancellationToken)
        {
            var cust = await _UserRepo.GetByIdAsync(request.Id);
            return _mapper.Map<UserDto>(cust);
        }
    }

}
