using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteImage
    {
        [JsonInclude, JsonPropertyName("1")]
        public string Size1 { get; internal set; }

        [JsonInclude, JsonPropertyName("1.5")]
        public string Size1AndHalf { get; internal set; }

        [JsonInclude, JsonPropertyName("1")]
        public string Size2 { get; internal set; }

        [JsonInclude, JsonPropertyName("2")]
        public string Size3 { get; internal set; }

        [JsonInclude, JsonPropertyName("4")]
        public string Size4 { get; internal set; }
    }
}
