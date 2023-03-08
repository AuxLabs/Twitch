using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class ShoutoutReceivedEventArgs
    {
        /// <summary> An ID that identifies the broadcaster that received the Shoutout. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> An ID that identifies the broadcaster that sent the Shoutout. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterId { get; internal set; }

        /// <summary> The broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_login")]
        public string FromBroadcasterName { get; internal set; }

        /// <summary> The broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_name")]
        public string FromBroadcasterDisplayName { get; internal set; }

        /// <summary> The number of users that were watching the from-broadcaster’s stream at the time of the Shoutout. </summary>
        [JsonInclude, JsonPropertyName("viewer_count")]
        public int ViewerCount { get; internal set; }

        /// <summary> The UTC timestamp of when the moderator sent the Shoutout. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }
    }
}
