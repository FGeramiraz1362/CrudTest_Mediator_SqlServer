using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class SettingDto
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
