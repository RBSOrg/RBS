using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Entities
{
    public class Table
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string RId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TId { get; set; }
        [Required]
        public int XCord { get; set; }
        [Required]
        public int YCord { get; set; }
        [Required]
        public decimal BookPrice { get; set; }
        [Required]
        [MaxLength(5)]
        public string Currency { get; set; }
        [Required]
        [MaxLength(500)]
        public string TableImgUrl { get; set; }
        public string Description { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
