using System;

namespace AuxLabs.SimpleTwitch
{
    public interface IUserFollow
    {
        /// <summary> The ID of the user that's following <see cref="BroadcasterId"/>. </summary>
        string UserId { get; set; }

        /// <summary> The follower’s login name. </summary>
        string UserName { get; set; }

        /// <summary> The follower’s display name. </summary>
        string UserDisplayName { get; set; }

        /// <summary> The ID of the user that’s being followed by <see cref="UserId"/>. </summary>
        string BroadcasterId { get; set; }

        /// <summary> The login name of the user that’s being followed. </summary>
        string BroadcasterName { get; set; }

        /// <summary> The display name of the user that’s being followed. </summary>
        string BroadcasterDisplayName { get; set; }

        /// <summary> The UTC date and time of when <see cref="UserId"/> began following <see cref="BroadcasterId"/>. </summary>
        DateTime FollowedAt { get; set; }
    }
}
