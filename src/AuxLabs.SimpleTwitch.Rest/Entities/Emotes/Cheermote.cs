using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class Cheermote
    {
        [JsonProperty("min_bits")]
        public int MinimumBits { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("images")]
        public EmoteTheme Images { get; set; }
        [JsonProperty("can_cheer")]
        public bool CanCheer { get; set; }
        [JsonProperty("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }
    }
}
