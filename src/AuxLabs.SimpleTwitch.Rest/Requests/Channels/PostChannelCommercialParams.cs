using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class PostChannelCommercialParams : IRequest
    {
        [JsonIgnore]
        public string[] Scopes { get; } = { "channel:edit:commercial" };

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }

        public PostChannelCommercialParams(string broadcasterId, int length)
            => (BroadcasterId, Length) = (broadcasterId, length);

    }
}
