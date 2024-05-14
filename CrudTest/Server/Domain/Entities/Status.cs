using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    [Table("Status")]
    public class Status : BaseEntity
    {
        [Required]
        public string Caption { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
