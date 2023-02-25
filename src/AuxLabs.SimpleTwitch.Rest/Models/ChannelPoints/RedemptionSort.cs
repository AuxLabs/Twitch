using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum RedemptionSort
    {
        [EnumMember(Value = "OLDEST")]
        Oldest = 0,

        [EnumMember(Value = "NEWEST")]
        Newest
    }
}
