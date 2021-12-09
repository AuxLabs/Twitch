using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public enum CostType
    {
        None = 0,
        [JsonProperty("bits")]
        Bits
    }
}
