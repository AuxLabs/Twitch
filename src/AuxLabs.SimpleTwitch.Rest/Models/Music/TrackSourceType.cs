using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<TrackSourceType>))]
    public enum TrackSourceType
    {
        [EnumMember(Value = "PLAYLIST")]
        Playlist,

        [EnumMember(Value = "STATION")]
        Station
    }
}
