using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class RaidEventArgs
    {
        /// <summary> The broadcaster ID that created the raid. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterId { get; internal set; }

        /// <summary> The broadcaster login that created the raid. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_login")]
        public string FromBroadcasterName { get; internal set; }

        /// <summary> The broadcaster display name that created the raid. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_name")]
        public string FromBroadcasterDisplayName { get; internal set; }

        /// <summary> The broadcaster ID that received the raid. </summary>
        [JsonInclude, JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadcasterId { get; internal set; }

        /// <summary> The broadcaster login that received the raid. </summary>
        [JsonInclude, JsonPropertyName("to_broadcaster_user_login")]
        public string ToBroadcasterName { get; internal set; }

        /// <summary> The broadcaster display name that received the raid. </summary>
        [JsonInclude, JsonPropertyName("to_broadcaster_user_name")]
        public string ToBroadcasterDisplayName { get; internal set; }

        /// <summary> The number of viewers in the raid. </summary>
        [JsonInclude, JsonPropertyName("viewers")]
        public int Viewers { get; internal set; }
    }
}
