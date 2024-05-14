using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{

    public class CommentDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Desciption { get; set; }

        public int ReplyTo { get; set; }

        [Required]
        public virtual BlogDto Blog { get; set; }
    }
}
