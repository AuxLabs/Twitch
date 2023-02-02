using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSub
    {
        /// <summary> An ID that identifies the subscription. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The subscription’s status. </summary>
        [JsonPropertyName("status")]
        public EventSubStatus Status { get; set; }

        /// <summary> The subscription’s type. </summary>
        [JsonPropertyName("type")]
        public EventSubType Type { get; set; }

        /// <summary> The version number that identifies this definition of the subscription’s data. </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary> The subscription’s parameter values. </summary>
        [JsonPropertyName("condition")]
        public IEventCondition Condition { get; set; }

        /// <summary> The date and time of when the subscription was created. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> The transport details used to send the notifications. </summary>
        [JsonPropertyName("transport")]
        public AcceptedTransport Transport { get; set; }

        /// <summary> The amount that the subscription counts against your limit. </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }
}
