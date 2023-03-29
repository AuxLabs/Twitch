using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class PostEventSubscriptionBody<TCondition> where TCondition : IEventCondition
    {
        /// <summary> The type of subscription to create. </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public EventSubType Type { get; set; }

        /// <summary> The version number that identifies the definition of the subscription type that you want the response to use. </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary> Parameter values that are specific to the specified subscription type. </summary>
        [JsonInclude, JsonPropertyName("condition")]
        public TCondition Condition { get; set; }

        /// <summary> The transport details that you want Twitch to use when sending you notifications. </summary>
        [JsonPropertyName("transport")]
        public Transport Transport { get; set; }

        public PostEventSubscriptionBody() { }

        /// <summary>
        ///     Constructor for websocket based event subscriptions.
        /// </summary>
        /// <param name="sessionId"> The session id of the websocket instance. </param>
        public PostEventSubscriptionBody(string sessionId)
        {
            Transport = new Transport
            {
                Method = TransportMethod.WebSocket,
                SessionId = sessionId
            };
        }

        /// <summary>
        ///     Constructor for webhook based event subscriptions
        /// </summary>
        /// <param name="callbackUrl"> The callback URL where the notifications are sent. </param>
        /// <param name="secret"> The secret used to verify the event signature. </param>
        public PostEventSubscriptionBody(string callbackUrl, string secret)
        {
            Transport = new Transport
            {
                Method = TransportMethod.Webhook,
                Callback = callbackUrl,
                Secret = secret
            };
        }

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
