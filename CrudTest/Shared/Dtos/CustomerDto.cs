using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Family { get; set; }

        public DateTime BirthDate { get; set; }

        public ulong MobileNumber { get; set; }

        public uint CountryCode { get; set; }

        public string Email { get; set; }

        public string BankAccounNumber { get; set; }


    }
}
