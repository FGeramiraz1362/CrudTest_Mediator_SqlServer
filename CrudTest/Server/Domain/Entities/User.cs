using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DebuggerDisplay("Family")]
        [StringLength(50, ErrorMessage = "{0} length must be between {1} and {2}", MinimumLength = 3)]
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
        public virtual Status Status { get; set; }
        [Required]
        public virtual Blog Blog { get; set; }
        [Required]
        public virtual Role Role { get; set; }
    }
}
