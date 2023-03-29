using System.Runtime.Serialization;

namespace AuxLabs.Twitch
{
    public enum PollStatus
    {
        /// <summary> Something went wrong while determining the state. </summary>
        [EnumMember(Value = "INVALID")]
        Invalid = 0,

        /// <summary> The poll is running. </summary>
        [EnumMember(Value = "ACTIVE")]
        Active,

        /// <summary> The poll ended on schedule. </summary>
        [EnumMember(Value = "COMPLETED")]
        Completed,

        /// <summary> The poll was terminated before its scheduled end. </summary>
        [EnumMember(Value = "TERMINATED")]
        Terminated,

        /// <summary> The poll has been archived and is no longer visible on the channel. </summary>
        [EnumMember(Value = "ARCHIVED")]
        Archived,

        /// <summary> The poll was deleted. </summary>
        [EnumMember(Value = "MODERATED")]
        Moderated
    }
}
