using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class PostChannelCommercialParams : BaseRequest
    {
        public override string[]? Scopes { get; } = { "channel:edit:commercial" };

        /// <summary>
        /// ID of the channel requesting a commercial
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary>
        /// Desired length of the commercial in seconds.
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }

        public PostChannelCommercialParams(string broadcasterId, int length)
            => (BroadcasterId, Length) = (broadcasterId, length);

    }
}
