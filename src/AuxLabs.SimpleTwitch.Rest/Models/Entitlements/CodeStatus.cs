using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public enum CodeStatus
    {
        /// <summary> The code has already been claimed. All codes are single-use. </summary>
        [EnumMember(Value = "ALREADY_CLAIMED")]
        AlreadyClaimed,

        /// <summary> The code has expired and can no longer be claimed. </summary>
        [EnumMember(Value = "EXPIRED")]
        Expired,

        /// <summary> The code has not been activated. </summary>
        [EnumMember(Value = "INACTIVE")]
        Inactive,

        /// <summary> The code is not properly formatted. </summary>
        [EnumMember(Value = "INCORRECT_FORMAT")]
        IncorrectFormat,

        /// <summary> An internal or unknown error occurred when checking the code. Retry later. </summary>
        [EnumMember(Value = "INTERNAL_ERROR")]
        InternalError,

        /// <summary> The code was not found. </summary>
        [EnumMember(Value = "NOT_FOUND")]
        NotFound,

        /// <summary> The code has not been claimed. </summary>
        [EnumMember(Value = "UNUSED")]
        Unused,

        /// <summary> The user is not eligible to redeem this code. </summary>
        [EnumMember(Value = "USER_NOT_ELIGIBLE")]
        UserNotEligible
    }
}
