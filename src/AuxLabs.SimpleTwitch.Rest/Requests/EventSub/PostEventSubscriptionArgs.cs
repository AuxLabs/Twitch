using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostEventSubscriptionArgs
    {
        /// <summary> The type of subscription to create. </summary>
        [JsonPropertyName("type")]
        public EventSubType Type { get; set; }

        /// <summary> The version number that identifies the definition of the subscription type that you want the response to use. </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary> Parameter values that are specific to the specified subscription type. </summary>
        [JsonPropertyName("condition")]
        public IEventCondition Condition { get; set; }

        /// <summary> The transport details that you want Twitch to use when sending you notifications. </summary>
        [JsonPropertyName("transport")]
        public AcceptedTransport Transport { get; set; }

        /// <summary> The amount that the subscription counts against your limit. </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }
}
