using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class ChannelEditor
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonConstructor]
        public ChannelEditor( string userId, string userName, DateTime createdAt)
            => (UserId, UserName, CreatedAt) = (userId, userName, createdAt);
    }
}
