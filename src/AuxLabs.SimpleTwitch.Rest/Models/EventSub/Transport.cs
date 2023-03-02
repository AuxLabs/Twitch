using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Transport
    {
        /// <summary> The transport method. </summary>
        [JsonPropertyName("method")]
        public TransportMethod Method { get; internal set; }

        /// <summary> The callback URL where the notifications are sent. Only required for webhooks. </summary>
        [JsonPropertyName("callback")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Callback { get; internal set; } = null;

        /// <summary> The secret used to verify the signature. Only required for webhooks. </summary>
        /// <remarks> The secret must be an ASCII string that’s a minimum of 10 characters long and a maximum of 100 characters long. </remarks>
        [JsonPropertyName("secret")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Secret { get; internal set; } = null;

        /// <summary> An ID that identifies the WebSocket to send notifications to. Only required for websockets. </summary>
        [JsonPropertyName("session_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SessionId { get; internal set; } = null;

        public Transport() { }
        public Transport(string sessionId)
        {
            Method = TransportMethod.WebSocket;
            SessionId = sessionId;
        }
        public Transport(string callback, string secret)
        {
            Method = TransportMethod.Webhook;
            Callback = callback;
            Secret = secret;
        }
    }
}
