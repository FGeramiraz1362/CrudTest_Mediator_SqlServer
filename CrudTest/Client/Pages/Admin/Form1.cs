using Microsoft.AspNetCore.Components;
using Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Client.Pages.Admin
{
    public partial class Form1
    {
        [Parameter]
        public UserDto User  { get; set; }
        public List<RoleDto> Roles { get; set; }

        [Parameter]
        public EventCallback Submit { get; set; }

        

        protected async override Task OnInitializedAsync()
        {
            var respone = await roleRepository.GetRoles();
            if(respone.Success)
            {
                Roles = respone.Response;
            }else
            {
                Console.WriteLine("Error");
            }

        }


    }
}
