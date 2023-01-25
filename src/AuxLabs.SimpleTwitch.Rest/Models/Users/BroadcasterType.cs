using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum BroadcasterType
    {
        None = 0,
        [EnumMember(Value = "partner")]
        Partner,
        [EnumMember(Value = "affiliate")]
        Affiliate
    }
}
