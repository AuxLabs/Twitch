﻿using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ScheduleSegment
    {
        /// <summary> An ID that identifies this broadcast segment. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The UTC date and time of when the broadcast starts. </summary>
        [JsonPropertyName("start_time")]
        public DateTime StartsAt { get; internal set; }

        /// <summary> The UTC date and time of when the broadcast ends. </summary>
        [JsonPropertyName("end_time")]
        public DateTime EndsAt { get; internal set; }

        /// <summary> The broadcast segment’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> Indicates whether the broadcaster canceled this segment of a recurring broadcast. </summary>
        [JsonPropertyName("canceled_until")]
        public DateTime? CancelledUntil { get; internal set; }

        /// <summary> The type of content that the broadcaster plans to stream. </summary>
        [JsonPropertyName("category")]
        public Category Category { get; internal set; }

        /// <summary> Determines whether the broadcast is part of a recurring series that streams at the same time each week or is a one-time broadcast. </summary>
        [JsonPropertyName("is_recurring")]
        public bool IsRecurring { get; internal set; }
    }
}
