using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum ProductType
    {
        None = 0,

        [EnumMember(Value = "BITS_IN_EXTENSION")]
        BitsInExtension
    }
}
