using System.Text.Json.Serialization;

namespace RBS.API.Models
{
    public class BaseCommandModel
    {
        [JsonIgnore]
        public Domain.UserModel UserModel { get; set; }
    }
}
