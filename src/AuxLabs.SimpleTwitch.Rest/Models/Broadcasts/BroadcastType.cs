using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum BroadcastType
    {
        Unknown = 0,

        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "live")]
        Live,
        [EnumMember(Value = "playlist")]
        Playlist,
        [EnumMember(Value = "watch_party")]
        WatchParty,
        [EnumMember(Value = "premiere")]
        Premiere,
        [EnumMember(Value = "rerun")]
        Rerun,
    }
}
