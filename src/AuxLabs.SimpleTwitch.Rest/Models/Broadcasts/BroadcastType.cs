using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum BroadcastType
    {
        Unknown = 0,

        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "live")]
        Live
    }
}
