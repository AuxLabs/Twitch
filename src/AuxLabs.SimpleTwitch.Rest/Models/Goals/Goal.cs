using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Goal
    {
        /// <summary> An ID that identifies this goal. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> An ID that identifies the broadcaster that created the goal. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The type of goal. </summary>
        [JsonPropertyName("type")]
        public GoalType Type { get; set; }

        /// <summary> A description of the goal. </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary> The goal’s current value. </summary>
        [JsonPropertyName("current_amount")]
        public int CurrentAmount { get; set; }

        /// <summary> The goal’s target value. </summary>
        [JsonPropertyName("target_amount")]
        public int TargetAmount { get; set; }

        /// <summary> The UTC date and time that the broadcaster created the goal. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
