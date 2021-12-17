using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public enum ProductType
    {
        None,
        [JsonPropertyName("BITS_IN_EXTENSION")]
        BitsInExtension
    }
}
