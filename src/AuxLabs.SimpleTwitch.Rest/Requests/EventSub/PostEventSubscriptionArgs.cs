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
        public Transport Transport { get; set; }

        public void Validate()
        {
            Require.NotEmptyOrWhitespace(Version, nameof(Version));
            Require.NotNull(Condition, nameof(Condition));
            Require.NotNull(Transport, nameof(Transport));

            if (Transport.Method == TransportMethod.WebSocket)
                Require.NotNullOrWhitespace(Transport.SessionId, nameof(Transport.SessionId), "Argument cannot be blank when using WebSocket Transport");

            if (Transport.Method == TransportMethod.Webhook)
            {
                Require.NotNullOrWhitespace(Transport.Callback, nameof(Transport.Callback), "Argument cannot be blank when using Webhook Transport");
                Require.NotNullOrWhitespace(Transport.Secret, nameof(Transport.Secret), "Argument cannot be blank when using Webhook Transport");
            }
        }
    }
}
