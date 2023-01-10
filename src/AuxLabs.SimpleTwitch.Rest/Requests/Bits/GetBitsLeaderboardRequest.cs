using AuxLabs.SimpleTwitch.Rest.Models;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetBitsLeaderboardRequest : BaseRequest
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("period")]
        public BitsPeriod Period { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
