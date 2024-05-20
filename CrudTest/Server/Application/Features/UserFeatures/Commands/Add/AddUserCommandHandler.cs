using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Repositories.Interfaces;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.UserFeatures.Commands.Add
{
    public class AddUserCommandModel : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public string Job { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }


        public int RoleId { get; set; }


    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommandModel, int>
    {
        private readonly IUserRepo _UserRepo;
        private readonly IValidator<AddUserCommandModel> _validator;

        public AddUserCommandHandler(IUserRepo UserRepo)
        {
            _UserRepo = UserRepo;

        }

        public async Task<int> Handle(AddUserCommandModel request, CancellationToken cancellationToken)
        {
            var User = new User
            {
                Email = request.Email.ToLower(),
                LastName = request.LastName.ToLower(),

                Name = request.Name.ToLower(),
                Job = request.Job,
                StatusId = 1,
                RoleId = request.RoleId,
                Password = "ss",
                Bio ="sss",
                BlogCount =1,
                Age =19,
            };
            await _UserRepo.AddAsync(User);
            return User.Id;
        }
    }
}
