using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{

    public class UserDto
    {
        public int Id { get; set; }
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

        //public string Bio { get; set; }

        //public int Age { get; set; }

        //public int BlogCount { get; set; }

        public int RoleId { get; set; }

 
        //public StatusDto Status { get; set; }

        //public BlogDto Blog { get; set; }

        //public RoleDto Role { get; set; }
    }
}
