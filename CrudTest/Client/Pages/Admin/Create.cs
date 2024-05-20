using Mc2.CrudTest.Presentation.Client.Repositories.UserRepositories;
using Microsoft.AspNetCore.Components;
using Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Client.Pages.Admin
{
    public partial class Create
    {

        public UserDto User { get; set; } = new UserDto();
        public bool ShowMessage { get; set; } = false;
        public string Message { get; set; }

        private async Task CreateUser()
        {
            await userRepository.AddUser(User);
            //For Create Message
            ShowMessage = true;
           // Message = "successful";

        }
    }
}
