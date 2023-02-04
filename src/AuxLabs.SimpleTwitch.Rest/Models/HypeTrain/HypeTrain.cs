using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class HypeTrain
    {
        /// <summary> The ID of the broadcaster that’s running the Hype Train. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The UTC date and time that another Hype Train can start. </summary>
        [JsonPropertyName("cooldown_end_time")]
        public DateTime CooldownEndsAt { get; set; }

        /// <summary> The UTC date and time that the Hype Train ends. </summary>
        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; set; }

        /// <summary> The value needed to reach the next level. </summary>
        [JsonPropertyName("goal")]
        public int Goal { get; set; }

        /// <summary> An ID that identifies this Hype Train. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The most recent contribution towards the Hype Train’s goal. </summary>
        [JsonPropertyName("last_contribution")]
        public HypeTrainContribution LastContribution { get; set; }

        /// <summary> The highest level that the Hype Train reached </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary> The UTC date and time that this Hype Train started. </summary>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        /// <summary> The top contributors for each contribution type. </summary>
        [JsonPropertyName("top_contributions")]
        public IReadOnlyCollection<HypeTrainContribution> TopContributions { get; set; }

        /// <summary> The current total amount raised. </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
