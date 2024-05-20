using Client.ServiceModel;
using Microsoft.AspNetCore.Components;
using Shared.Dtos;
using static MudBlazor.Icons;

namespace Mc2.CrudTest.Presentation.Client.Pages.Admin
{
    public partial class Edit
    {
        public UserDto User { get; set; } = new UserDto();
        public bool ShowMessage { get; set; } = false;
        public string Message { get; set; }

        private async Task EditUser()
        {
            //For Create Message
            ShowMessage = true;
            Message = "successful";

        }
        protected override async Task OnInitializedAsync()
        {
            // User =
        }

    }
}
