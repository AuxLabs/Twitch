using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubscription
    {
        /// <summary> Your client ID. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The notification’s subscription type in raw string form. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public string TypeRaw { get; internal set; }

        /// <summary> The notification’s subscription type. </summary>
        [JsonIgnore]
        public EventSubType Type => EnumHelper.GetEnumValue<EventSubType>(TypeRaw);

        /// <summary> The version of the subscription. </summary>
        [JsonInclude, JsonPropertyName("version")]
        public string Version { get; internal set; }

        /// <summary> The status of the subscription. </summary>
        [JsonInclude, JsonPropertyName("status")]
        public EventSubStatus Status { get; internal set; }

        /// <summary> How much the subscription counts against your limit. </summary>
        [JsonInclude, JsonPropertyName("cost")]
        public int Cost { get; internal set; }

        /// <summary> Subscription-specific parameters. </summary>
        [JsonInclude, JsonPropertyName("condition")]
        public IEventCondition Condition { get; internal set; }

        /// <summary> Information about the transport used for this subscription. </summary>
        [JsonInclude, JsonPropertyName("transport")]
        public Transport Transport { get; internal set; }

        /// <summary> The time the notification was created. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }
    }
}
