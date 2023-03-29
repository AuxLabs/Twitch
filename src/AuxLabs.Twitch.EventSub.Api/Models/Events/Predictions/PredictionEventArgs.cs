using AuxLabs.Twitch.Rest.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class PredictionEventArgs
    {
        /// <summary> The prediction identifier. </summary>
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

        /// <summary> Title for the Channel Points Prediction. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> A collection of outcomes for the Channel Points Prediction. </summary>
        [JsonInclude, JsonPropertyName("outcomes")]
        public IReadOnlyCollection<PredictionOption> Options { get; internal set; }

        /// <summary> The time the Channel Points Prediction started. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }

        /// <summary> The time the Channel Points Prediction will automatically lock. </summary>
        [JsonInclude, JsonPropertyName("locks_at")]
        public DateTime LocksAt { get; internal set; }
    }
}
