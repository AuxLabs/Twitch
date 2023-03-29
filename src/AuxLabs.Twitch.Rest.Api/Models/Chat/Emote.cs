using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Emote : GlobalEmote
    {
        /// <summary> The subscriber tier at which the emote is unlocked. </summary>
        [JsonInclude, JsonPropertyName("tier")]
        public string Tier { get; internal set; }

        /// <summary> The type of emote. </summary>
        [JsonInclude, JsonPropertyName("emote_type")]
        public EmoteType Type { get; internal set; }

        /// <summary> An ID that identifies the emote set that the emote belongs to. </summary>
        [JsonInclude, JsonPropertyName("emote_set_id")]
        public string EmoteSetId { get; internal set; }

        /// <summary> The ID of the broadcaster who owns the emote. </summary>
        [JsonInclude, JsonPropertyName("owner_id")]
        public string BroadcasterId { get; internal set; }
    }
}
