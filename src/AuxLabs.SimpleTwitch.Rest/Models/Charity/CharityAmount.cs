using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public struct CharityAmount
    {
        /// <summary> The monetary amount in the currency’s minor unit. </summary>
        [JsonInclude, JsonPropertyName("value")]
        public int Value { get; internal set; }

        /// <summary> The number of decimal places used by the currency. </summary>
        [JsonInclude, JsonPropertyName("decimal_places")]
        public int DecimalPlaces { get; internal set; }

        /// <summary> The ISO-4217 three-letter currency code that identifies the type of currency. </summary>
        [JsonInclude, JsonPropertyName("currency")]
        public string Currency { get; internal set; }
    }
}
