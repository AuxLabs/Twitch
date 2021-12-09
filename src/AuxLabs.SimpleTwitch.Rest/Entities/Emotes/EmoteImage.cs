using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class EmoteImage
    {
        [JsonProperty("1")]
        public string Size1 { get; set; }
        [JsonProperty("1.5")]
        public string Size15 { get; set; }
        [JsonProperty("1")]
        public string Size2 { get; set; }
        [JsonProperty("2")]
        public string Size3 { get; set; }
        [JsonProperty("4")]
        public string Size4 { get; set; }
    }
}
