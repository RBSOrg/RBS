using System.ComponentModel.DataAnnotations;

namespace RBS.Domain
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }
        [Required]
        [MaxLength(20)]
        public int City { get; set; }
        [Required]
        [MaxLength(10)]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        public decimal GPSLattitude { get; set; }
        public decimal GPSLongitude { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
