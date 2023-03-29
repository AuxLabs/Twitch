﻿using AuxLabs.Twitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class PredictionEndedEventArgs : PredictionEventArgs
    {
        /// <summary> ID of the winning outcome. </summary>
        [JsonInclude, JsonPropertyName("winning_outcome_id")]
        public string WinningOptionId { get; internal set; }

        /// <summary> The status of the Channel Points Prediction. </summary>
        [JsonInclude, JsonPropertyName("status")]
        public PredictionStatus Status { get; internal set; }
    }
}