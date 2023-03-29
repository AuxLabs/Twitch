using System.Runtime.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public enum DropStatus
    {
        /// <summary> The entitlement IDs are not valid. </summary>
        [EnumMember(Value = "INVALID_ID")]
        InvalidId,

        /// <summary> The entitlement IDs were not found. </summary>
        [EnumMember(Value = "NOT_FOUND")]
        NotFound,

        /// <summary> The status of the entitlements were successfully updated. </summary>
        [EnumMember(Value = "SUCCESS")]
        Success,

        /// <summary> The user or organization identified by the user access token is not authorized to update the entitlements. </summary>
        [EnumMember(Value = "UNAUTHORIZED")]
        Unauthorized,

        /// <summary> The update failed. These are considered transient errors and the request should be retried later. </summary>
        [EnumMember(Value = "UPDATE_FAILED")]
        UpdateFailed
    }
}
