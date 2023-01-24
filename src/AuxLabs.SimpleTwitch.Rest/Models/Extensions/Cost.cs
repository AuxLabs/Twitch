using AuxLabs.SimpleTwitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Cost
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; init; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<CostType>))]
        public CostType Type { get; init; }
    }
}
