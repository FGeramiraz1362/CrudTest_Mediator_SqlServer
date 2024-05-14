using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        public string FnCaption { get; set; }
        [Required]
        public string EnCaption { get; set; }
        

    }
}
