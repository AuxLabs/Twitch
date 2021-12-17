using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class EmoteImage
    {
        [JsonPropertyName("1")]
        public string Size1 { get; set; }
        [JsonPropertyName("1.5")]
        public string Size15 { get; set; }
        [JsonPropertyName("1")]
        public string Size2 { get; set; }
        [JsonPropertyName("2")]
        public string Size3 { get; set; }
        [JsonPropertyName("4")]
        public string Size4 { get; set; }

        [JsonConstructor]
        public EmoteImage(string size1, string size15, string size2, string size3, string size4)
            => (Size1, Size15, Size2, Size3, Size4) = (size1, size15, size2, size3, size4);
    }
}
