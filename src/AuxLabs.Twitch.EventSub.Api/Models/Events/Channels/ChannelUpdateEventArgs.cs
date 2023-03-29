using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class ChannelUpdateEventArgs
    {
        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The channel’s stream title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The channel’s broadcast language. </summary>
        [JsonInclude, JsonPropertyName("language")]
        public string Language { get; internal set; }

        /// <summary> The channel’s category ID. </summary>
        [JsonInclude, JsonPropertyName("category_id")]
        public string CategoryId { get; internal set; }

        /// <summary> The category name. </summary>
        [JsonInclude, JsonPropertyName("category_name")]
        public string CategoryName { get; internal set; }

        /// <summary> Indicates whether the channel is flagged as mature. </summary>
        [JsonInclude, JsonPropertyName("is_mature")]
        public bool IsMature { get; internal set; }
    }
}
