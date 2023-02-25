using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum ProductType
    {
        None = 0,

        [EnumMember(Value = "BITS_IN_EXTENSION")]
        BitsInExtension
    }
}
