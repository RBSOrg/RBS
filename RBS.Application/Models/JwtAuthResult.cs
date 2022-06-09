using System.Text.Json.Serialization;

namespace RBS.Application.Models
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = default!;

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; } = default!;
    }
}
