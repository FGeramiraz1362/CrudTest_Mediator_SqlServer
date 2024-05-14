using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{

    public class BlogDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Desciption { get; set; }

        public string Photo { get; set; }
        [Required]
        public int likes { get; set; }
        [Required]
        public int Dislikes { get; set; }

    }
}
