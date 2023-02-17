using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Entitlement
    {
        /// <summary> An ID that identifies the entitlement. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> An ID that identifies the benefit (reward). </summary>
        [JsonPropertyName("benefit_id")]
        public string BenefitId { get; set; }

        /// <summary> The UTC date and time of when the entitlement was granted. </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary> An ID that identifies the user who was granted the entitlement. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> An ID that identifies the game the user was playing when the reward was entitled. </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        /// <summary> The entitlement’s fulfillment status. </summary>
        [JsonPropertyName("fulfillment_status")]
        public FulfillmentStatus Status { get; set; }

        /// <summary> The UTC date and time of when the entitlement was last updated. </summary>
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdatedAt { get; set; }
    }
}
