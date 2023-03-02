using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ChannelTeam : SimpleTeam
    {
        /// <summary> An ID that identifies the broadcaster. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

    }
}
