using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Shared.Dtos
{

    public class UserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Job { get; set; }

        public string Bio { get; set; }

        public int Age { get; set; }

        public int BlogCount { get; set; }
        [Required]
        public StatusDto Status { get; set; }
        [Required]
        public BlogDto Blog { get; set; }
        [Required]
        public RoleDto Role { get; set; }
    }
}
