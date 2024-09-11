using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Postcode { get; set; }
    }
}
