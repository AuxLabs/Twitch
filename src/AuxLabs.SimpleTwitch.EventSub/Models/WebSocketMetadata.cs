using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class WebSocketMetadata
    {
        /// <summary> An ID that uniquely identifies the message. </summary>
        [JsonPropertyName("message_id")]
        public string Id { get; set; }

        /// <summary> The type of message, in a raw string format. </summary>
        [JsonPropertyName("message_type")]
        public string TypeRaw { get; set; }

        /// <summary> The type of message. </summary>
        [JsonIgnore]
        public MessageType Type => EnumHelper.GetValueFromEnumMember<MessageType>(TypeRaw);

        /// <summary> The UTC date and time that the message was sent. </summary>
        [JsonPropertyName("message_timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary> The type of event sent in the message. </summary>
        [JsonPropertyName("subscription_type")]
        public string SubscriptionType { get; set; }

        /// <summary> The version number of the subscription type’s definition. This is the same value specified in the subscription request. </summary>
        [JsonPropertyName("subscription_version")]
        public string SubscriptionVersion { get; set; }
    }
}
