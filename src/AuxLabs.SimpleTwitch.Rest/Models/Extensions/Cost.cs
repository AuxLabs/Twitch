using AuxLabs.SimpleTwitch.Rest.Net;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Cost
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; init; } = default!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<CostType>))]
        public CostType Type { get; init; } = default!;
    }
}
