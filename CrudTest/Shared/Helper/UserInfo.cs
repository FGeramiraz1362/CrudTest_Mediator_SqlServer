using System.ComponentModel.DataAnnotations;

namespace Shared.Helper
{
    public class UserInfo
    {
        [Required(ErrorMessage ="Email Is Mandatory")]
        [EmailAddress(ErrorMessage = "Email is Not Correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Mandatory")]
        public string Password { get; set; }
    }
}
