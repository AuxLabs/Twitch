using AuxLabs.SimpleTwitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Cost
    {
        /// <summary> The amount exchanged for the digital product. </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary> The type of currency exchanged. </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<CostType>))]
        public CostType Type { get; set; }
    }
}
