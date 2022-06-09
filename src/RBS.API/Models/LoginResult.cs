using System.Text.Json.Serialization;

namespace RBS.Api.Models
{
    public class LoginResult
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = default!;

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = default!;

        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; } = default!;

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = default!;

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; } = default!;
    }
}
