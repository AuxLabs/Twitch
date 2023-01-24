using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class Session
    {
        /// <summary>
        /// An ID that uniquely identifies this WebSocket connection.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The connection’s status.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The maximum number of seconds that you should expect silence before receiving a keepalive message.
        /// </summary>
        [JsonPropertyName("keepalive_timeout_seconds")]
        public int? KeepaliveTimeoutSeconds { get; set; }

        /// <summary>
        /// The URL to reconnect to if you get a Reconnect message.
        /// </summary>
        [JsonPropertyName("reconnect_url")]
        public string ReconnectUrl { get; set; }

        /// <summary>
        /// The UTC date and time that the connection was created.
        /// </summary>
        [JsonPropertyName("connected_at")]
        public DateTime ConnectedAt { get; set; }
    }
}
