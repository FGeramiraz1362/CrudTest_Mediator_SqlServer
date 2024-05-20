using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    [Table("Blogs")]
 
    public class Blog : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Desciption { get; set; }

        public string Photo { get; set; } = null;
        [Required]
        public int likes { get; set; } = 0;
        [Required]
        public int Dislikes { get; set; } = 0;
        public virtual User User { get; set; }

    }
}
