using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RBS.Api.Models
{
    public class LogInRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
