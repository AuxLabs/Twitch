using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class HypeTrain
    {
        /// <summary> The ID of the broadcaster that’s running the Hype Train. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The UTC date and time that another Hype Train can start. </summary>
        [JsonInclude, JsonPropertyName("cooldown_end_time")]
        public DateTime CooldownEndsAt { get; internal set; }

        /// <summary> The UTC date and time that the Hype Train ends. </summary>
        [JsonInclude, JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; internal set; }

        /// <summary> The value needed to reach the next level. </summary>
        [JsonInclude, JsonPropertyName("goal")]
        public int Goal { get; internal set; }

        /// <summary> An ID that identifies this Hype Train. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The most recent contribution towards the Hype Train’s goal. </summary>
        [JsonInclude, JsonPropertyName("last_contribution")]
        public HypeTrainContribution LastContribution { get; internal set; }

        /// <summary> The highest level that the Hype Train reached </summary>
        [JsonInclude, JsonPropertyName("level")]
        public int Level { get; internal set; }

        /// <summary> The UTC date and time that this Hype Train started. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }

        /// <summary> The top contributors for each contribution type. </summary>
        [JsonInclude, JsonPropertyName("top_contributions")]
        public IReadOnlyCollection<HypeTrainContribution> TopContributions { get; internal set; }

        /// <summary> The current total amount raised. </summary>
        [JsonInclude, JsonPropertyName("total")]
        public int Total { get; internal set; }
    }
}
