using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public enum ProductType
    {
        None,
        [JsonProperty("BITS_IN_EXTENSION")]
        BitsInExtension
    }
}
