using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Dtos
{
    public class RoleDto
    {
        [Required]
        public string FnCaption { get; set; }
        [Required]
        public string EnCaption { get; set; }


    }
}
