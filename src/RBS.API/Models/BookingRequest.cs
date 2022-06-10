using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RBS.API.Models
{
    public class BookingRequest : BaseCommandModel
    {
        [Required]
        [JsonPropertyName("RestaurantId")]
        public string RId { get; set; }
        [Required]
        [JsonPropertyName("TabeleId")]
        public string TId { get; set; }
        [Required]
        [JsonPropertyName("BookDateTime")]
        public DateTime BookDateTime { get; set; }
    }
}
