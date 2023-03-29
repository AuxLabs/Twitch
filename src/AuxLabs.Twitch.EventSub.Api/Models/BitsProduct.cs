using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class BitsProduct
    {
        /// <summary> Product name. </summary>
        [JsonInclude, JsonPropertyName("name")]
        public string Name { get; internal set; }

        /// <summary> Bits involved in the transaction. </summary>
        [JsonInclude, JsonPropertyName("bits")]
        public int BitsAmount { get; internal set; }

        /// <summary> Unique identifier for the product acquired. </summary>
        [JsonInclude, JsonPropertyName("sku")]
        public string Sku { get; internal set; }

        /// <summary> Flag indicating if the product is in development. </summary>
        [JsonInclude, JsonPropertyName("in_development")]
        public bool IsDevelopment { get; internal set; }
    }
}
