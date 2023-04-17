using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class ChannelTeam : PartialTeam
    {
        /// <summary> An ID that identifies the broadcaster. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

    }
}
