using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class EmoteTheme
    {
        [JsonProperty("dark")]
        public EmoteFormat Dark { get; set; }
        [JsonProperty("light")]
        public EmoteFormat Light { get; set; }
    }
}
