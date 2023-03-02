using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ChannelBroadcast : Channel
    {
        /// <summary> Determines whether the broadcaster is streaming live. </summary>
        [JsonInclude, JsonPropertyName("is_live")]
        public bool IsLive { get; internal set; }

        /// <summary> A URL to a thumbnail of the broadcaster’s profile image. </summary>
        [JsonInclude, JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; internal set; }

        /// <summary> The UTC date and time of when the broadcaster started streaming. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }
    }
}
