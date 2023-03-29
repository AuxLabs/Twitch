using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class HypeTrainEndedEventArgs
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

        /// <summary> The starting level of the Hype Train. </summary>
        [JsonInclude, JsonPropertyName("level")]
        public int Level { get; internal set; }

        /// <summary> Total points contributed to the Hype Train. </summary>
        [JsonInclude, JsonPropertyName("total")]
        public int Total { get; internal set; }

        /// <summary> The contributors with the most points contributed. </summary>
        [JsonInclude, JsonPropertyName("top_contributions")]
        public IReadOnlyCollection<EventSubHypetrainContribution> TopContributions { get; internal set; }

        /// <summary> The time when the Hype Train started. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }

        /// <summary> The time when the Hype Train ended. </summary>
        [JsonInclude, JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; internal set; }

        /// <summary> The time when the Hype Train cooldown ends so that the next Hype Train can start. </summary>
        [JsonInclude, JsonPropertyName("cooldown_ends_at")]
        public DateTime CooldownEndsAt { get; internal set; }
    }
}
