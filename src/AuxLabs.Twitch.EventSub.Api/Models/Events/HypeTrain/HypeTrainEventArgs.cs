using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class HypeTrainEventArgs
    {
        /// <summary> The Hype Train ID. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> Total points contributed to the Hype Train. </summary>
        [JsonInclude, JsonPropertyName("total")]
        public int Total { get; internal set; }

        /// <summary> The number of points contributed to the Hype Train at the current level. </summary>
        [JsonInclude, JsonPropertyName("progress")]
        public int Progress { get; internal set; }

        /// <summary> The number of points required to reach the next level. </summary>
        [JsonInclude, JsonPropertyName("goal")]
        public int Goal { get; internal set; }

        /// <summary> The contributors with the most points contributed. </summary>
        [JsonInclude, JsonPropertyName("top_contributions")]
        public IReadOnlyCollection<EventSubHypetrainContribution> TopContributions { get; internal set; }

        /// <summary> The most recent contribution. </summary>
        [JsonInclude, JsonPropertyName("last_contribution")]
        public EventSubHypetrainContribution LatestContribution { get; internal set; }

        /// <summary> The starting level of the Hype Train. </summary>
        [JsonInclude, JsonPropertyName("level")]
        public int Level { get; internal set; }

        /// <summary> The time when the Hype Train started. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }

        /// <summary> The time when the Hype Train expires. </summary>
        /// <remarks> The expiration is extended when the Hype Train reaches a new level. </remarks>
        [JsonInclude, JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; internal set; }
    }
}
