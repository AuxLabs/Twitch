using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class Cost
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("type")]
        public CostType Type { get; set; }
    }
}
