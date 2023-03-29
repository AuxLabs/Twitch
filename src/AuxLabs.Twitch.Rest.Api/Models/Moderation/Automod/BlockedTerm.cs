using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class BlockedTerm
    {
        /// <summary> The broadcaster that owns the list of blocked terms. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The moderator that blocked the word or phrase from being used in the broadcaster’s chat room. </summary>
        [JsonInclude, JsonPropertyName("moderator_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> An ID that identifies this blocked term. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The blocked word or phrase. </summary>
        [JsonInclude, JsonPropertyName("text")]
        public string Text { get; internal set; }

        /// <summary> The UTC date and time that the term was blocked. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> The UTC date and time that the term was updated. </summary>
        [JsonInclude, JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; internal set; }

        /// <summary> The UTC date and time that the blocked term is set to expire. </summary>
        [JsonInclude, JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; internal set; }
    }
}
