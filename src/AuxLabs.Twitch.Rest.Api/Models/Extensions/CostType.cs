using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum CostType
    {
        None = 0,

        [EnumMember(Value = "bits")]
        Bits
    }
}
