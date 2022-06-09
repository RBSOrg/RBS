using System.Text.Json.Serialization;

namespace RBS.Application.Models
{
    public class RefreshToken
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = default!;

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; } = default!;

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
