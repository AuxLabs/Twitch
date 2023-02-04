using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<ProductType>))]
    public enum ProductType
    {
        None = 0,

        [EnumMember(Value = "BITS_IN_EXTENSION")]
        BitsInExtension
    }
}
