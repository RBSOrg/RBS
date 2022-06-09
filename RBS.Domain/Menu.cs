using System.ComponentModel.DataAnnotations;

namespace RBS.Domain
{
    public class Menu
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Rid { get; set; }
        [Required]
        [MaxLength(30)]
        public string Mid { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        //public ICollection<Product> Products { get; set; }
        public string Description { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
