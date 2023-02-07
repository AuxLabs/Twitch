using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class ChannelUpdateEventArgs
    {
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; set; }

        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }

        [JsonPropertyName("is_mature")]
        public bool IsMature { get; set; }
    }
}
