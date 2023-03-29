﻿using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Transport
    {
        /// <summary> The transport method. </summary>
        [JsonInclude, JsonPropertyName("method")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TransportMethod Method { get; internal set; }

        /// <summary> The callback URL where the notifications are sent. Only required for webhooks. </summary>
        [JsonInclude, JsonPropertyName("callback")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Callback { get; internal set; } = null;

        /// <summary> The secret used to verify the signature. Only required for webhooks. </summary>
        /// <remarks> The secret must be an ASCII string that’s a minimum of 10 characters long and a maximum of 100 characters long. </remarks>
        [JsonInclude, JsonPropertyName("secret")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Secret { get; internal set; } = null;

        /// <summary> An ID that identifies the WebSocket to send notifications to. Only required for websockets. </summary>
        [JsonInclude, JsonPropertyName("session_id")]
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
