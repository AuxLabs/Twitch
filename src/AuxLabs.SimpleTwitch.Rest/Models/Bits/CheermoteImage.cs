using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CheermoteImage
    {
        [JsonPropertyName("1")]
        public string Size1 { get; set; }

        [JsonPropertyName("1.5")]
        public string Size1AndHalf { get; set; }

        [JsonPropertyName("1")]
        public string Size2 { get; set; }

        [JsonPropertyName("2")]
        public string Size3 { get; set; }

        [JsonPropertyName("4")]
        public string Size4 { get; set; }
    }
}
