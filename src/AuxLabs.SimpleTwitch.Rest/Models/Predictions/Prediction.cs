using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Prediction
    {
        /// <summary> An ID that identifies this prediction. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> An ID that identifies the broadcaster that created the prediction. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The question that the prediction asks. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The ID of the winning outcome. </summary>
        [JsonPropertyName("winning_outcome_id")]
        public string WinningOutcomeId { get; set; }

        /// <summary> A collection of possible outcomes for the prediction. </summary>
        [JsonPropertyName("outcomes")]
        public IReadOnlyCollection<PredictionOption> Outcomes { get; set; }

        /// <summary> The length of time that the prediction will run for. </summary>
        [JsonPropertyName("prediction_window")]
        public int PredictionDurationSeconds { get; set; }

        /// <summary> The prediction’s status. </summary>
        [JsonPropertyName("status")]
        public PredictionStatus Status { get; set; }

        /// <summary> The UTC date and time of when the Prediction began. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> The UTC date and time of when the Prediction ended. </summary>
        [JsonPropertyName("ended_at")]
        public DateTime? EndedAt { get; set; }

        /// <summary> The UTC date and time of when the Prediction was locked. </summary>
        [JsonPropertyName("locked_at")]
        public DateTime? LockedAt { get; set; }
    }
}
