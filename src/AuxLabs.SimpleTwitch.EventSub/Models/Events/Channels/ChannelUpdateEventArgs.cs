using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class ChannelUpdateEventArgs
    {
        /// <summary> The requested broadcaster ID. </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The channel’s stream title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The channel’s broadcast language. </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary> The channel’s category ID. </summary>
        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        /// <summary> The category name. </summary>
        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }

        /// <summary> Indicates whether the channel is flagged as mature. </summary>
        [JsonPropertyName("is_mature")]
        public bool IsMature { get; set; }
    }
}
