using System.ComponentModel.DataAnnotations;

namespace RBS.Domain
{
    public class Restaurant
    {
        [Required]
        [MaxLength(500)]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string Run { get; set; }
        [Required]
        [MaxLength(20)]
        public string RId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public decimal Stars { get; set; }
        [DataType(DataType.Date)]
        public DateTime OpenTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime CloseTime { get; set; }
        public decimal TBookPrice { get; set; }
        [MaxLength(5)]
        public string Currency { get; set; }


        public ICollection<Menu> Menus { get; set; }
        public Address Address { get; set; }
        public ICollection<RestaurantType> RestaurantTypes { get; set; }
        public ICollection<Img> Imgs { get; set; }
        public ICollection<Table> Tables { get; set; }

    }
}
