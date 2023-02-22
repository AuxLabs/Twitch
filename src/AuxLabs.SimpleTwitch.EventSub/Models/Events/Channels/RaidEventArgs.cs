using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class RaidEventArgs
    {
        /// <summary> The broadcaster ID that created the raid. </summary>
        [JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterId { get; set; }

        /// <summary> The broadcaster login that created the raid. </summary>
        [JsonPropertyName("from_broadcaster_user_login")]
        public string FromBroadcasterName { get; set; }

        /// <summary> The broadcaster display name that created the raid. </summary>
        [JsonPropertyName("from_broadcaster_user_name")]
        public string FromBroadcasterDisplayName { get; set; }

        /// <summary> The broadcaster ID that received the raid. </summary>
        [JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadcasterId { get; set; }

        /// <summary> The broadcaster login that received the raid. </summary>
        [JsonPropertyName("to_broadcaster_user_login")]
        public string ToBroadcasterName { get; set; }

        /// <summary> The broadcaster display name that received the raid. </summary>
        [JsonPropertyName("to_broadcaster_user_name")]
        public string ToBroadcasterDisplayName { get; set; }

        /// <summary> The number of viewers in the raid. </summary>
        [JsonPropertyName("viewers")]
        public int Viewers { get; set; }
    }
}
