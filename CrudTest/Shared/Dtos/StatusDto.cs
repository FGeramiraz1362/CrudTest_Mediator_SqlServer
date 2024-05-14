using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class StatusDto
    {
        [Required]
        public string Caption { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
