using System.ComponentModel.DataAnnotations;

namespace RBS.Domain
{
    public class Img
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Rid { get; set; }
        [Required]
        [MaxLength(500)]
        public string IUrl { get; set; }
        [MaxLength(500)]
        public string ClickUrl { get; set; }
        public int OrderPriority { get; set; }
        public string Description { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
