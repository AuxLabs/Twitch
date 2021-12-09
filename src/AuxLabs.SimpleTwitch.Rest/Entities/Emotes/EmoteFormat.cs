using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class EmoteFormat
    {
        [JsonProperty("animated")]
        public EmoteImage Animated { get; set; }
        [JsonProperty("static")]
        public EmoteImage Static { get; set; }
    }
}
