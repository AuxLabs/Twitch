using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum TrackSourceType
    {
        [EnumMember(Value = "PLAYLIST")]
        Playlist,

        [EnumMember(Value = "STATION")]
        Station
    }
}
