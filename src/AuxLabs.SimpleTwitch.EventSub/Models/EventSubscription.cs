﻿using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubscription
    {
        /// <summary> Your client ID. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The notification’s subscription type in raw string form. </summary>
        [JsonPropertyName("type")]
        public string TypeRaw { get; set; }

        /// <summary> The notification’s subscription type. </summary>
        [JsonIgnore]
        public EventSubType Type => EnumHelper.GetEnumValue<EventSubType>(TypeRaw);

        /// <summary> The version of the subscription. </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary> The status of the subscription. </summary>
        [JsonPropertyName("status")]
        public EventSubStatus Status { get; set; }

        /// <summary> How much the subscription counts against your limit. </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        /// <summary> Subscription-specific parameters. </summary>
        [JsonPropertyName("condition")]
        public IEventCondition Condition { get; set; }

        /// <summary> Information about the transport used for this subscription. </summary>
        [JsonPropertyName("transport")]
        public Transport Transport { get; set; }

        /// <summary> The time the notification was created. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}