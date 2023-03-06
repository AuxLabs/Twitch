using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EventSub : EventSub<IEventCondition> { }
    public class EventSub<TCondition> where TCondition : IEventCondition
    {
        /// <summary> An ID that identifies the subscription. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The subscription’s status. </summary>
        [JsonInclude, JsonPropertyName("status")]
        public EventSubStatus Status { get; internal set; }

        /// <summary> The subscription’s type. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public EventSubType Type { get; internal set; }

        /// <summary> The version number that identifies this definition of the subscription’s data. </summary>
        [JsonInclude, JsonPropertyName("version")]
        public string Version { get; internal set; }

        /// <summary> The subscription’s parameter values. </summary>
        [JsonInclude, JsonPropertyName("condition")]
        public TCondition Condition { get; internal set; }

        /// <summary> The date and time of when the subscription was created. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> The transport details used to send the notifications. </summary>
        [JsonInclude, JsonPropertyName("transport")]
        public AcceptedTransport Transport { get; internal set; }

        /// <summary> The amount that the subscription counts against your limit. </summary>
        [JsonInclude, JsonPropertyName("cost")]
        public int Cost { get; internal set; }
    }
}
