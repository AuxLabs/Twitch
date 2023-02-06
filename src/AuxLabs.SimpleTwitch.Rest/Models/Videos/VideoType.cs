using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum VideoType
    {
        [EnumMember(Value = "all")]
        All = 0,

        /// <summary> An on-demand video (VOD) of one of the broadcaster's past streams. </summary>
        [EnumMember(Value = "archive")]
        Archive,

        /// <summary> A highlight reel of one of the broadcaster's past streams. </summary>
        [EnumMember(Value = "highlight")]
        Highlight,

        /// <summary> A video that the broadcaster uploaded to their video library. </summary>
        [EnumMember(Value = "upload")]
        Upload
    }
}
