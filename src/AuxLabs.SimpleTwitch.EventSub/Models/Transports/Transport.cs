namespace AuxLabs.SimpleTwitch.EventSub
{
    public class Transport
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("method")]
        public TransportMethod Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("callback")]
        public string Callback { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("connected_at")]
        public DateTime ConnectedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("disconnected_at")]
        public DateTime DisconnectedAt { get; set; }
    }
}
