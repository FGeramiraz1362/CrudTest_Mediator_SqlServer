using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    [Table("Comments")]
    
    public class Comment : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Desciption { get; set; }

        public int ReplyTo { get; set; }

        [Required]
        public virtual Blog Blog { get; set; }
    }
}
