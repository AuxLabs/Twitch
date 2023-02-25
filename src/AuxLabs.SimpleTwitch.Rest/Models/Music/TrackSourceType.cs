using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum TrackSourceType
    {
        [EnumMember(Value = "PLAYLIST")]
        Playlist,

        [EnumMember(Value = "STATION")]
        Station
    }
}
