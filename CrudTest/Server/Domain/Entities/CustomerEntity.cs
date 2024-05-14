using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    [Table("Customers")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Name), nameof(Family), nameof(BirthDate), IsUnique = true)]
    public class CustomerEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DebuggerDisplay("Family")]
        [StringLength(500, ErrorMessage = "{0} length must be between {1} and {2}", MinimumLength = 3)]
        public string Family { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0}:yyyy/mm/dd", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public PhoneNumebrEntity PhoneNumebr { get; set; }
     
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string BankAccounNumber { get; set; }

        [Owned()]
        public class PhoneNumebrEntity
        {
            [Required]
            public ulong MobileNumber { get; set; }
            [Required]
            public uint CountryCode { get; set; }
        }

    }
}
