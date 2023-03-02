using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AcceptedTransport : Transport
    {
        /// <summary> The date and time that the WebSocket was connected. Only specified for websockets. </summary>
        [JsonInclude, JsonPropertyName("connected_at")]
        public DateTime ConnectedAt { get; internal set; }

        /// <summary> The date and time that the WebSocket was disconnected. Only specified for websockets. </summary>
        [JsonInclude, JsonPropertyName("disconnected_at")]
        public DateTime DisconnectedAt { get; internal set; }
    }
}
