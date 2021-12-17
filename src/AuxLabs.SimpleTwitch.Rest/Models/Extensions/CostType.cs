using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public enum CostType
    {
        None = 0,
        [JsonPropertyName("bits")]
        Bits
    }
}
