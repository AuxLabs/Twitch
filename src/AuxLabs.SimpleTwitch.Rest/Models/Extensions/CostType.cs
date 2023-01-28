using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum CostType
    {
        None = 0,

        [EnumMember(Value = "bits")]
        Bits
    }
}
