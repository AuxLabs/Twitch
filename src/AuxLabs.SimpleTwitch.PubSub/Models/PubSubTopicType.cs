using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.PubSub
{
    public enum PubSubTopicType
    {
        Unknown = 0,

        /// <summary> Anyone cheers in a specified channel. </summary>
        /// <remarks> Requires the <c>bits:read</c> scope. </remarks>
        [EnumMember(Value = "channel-bits-events-v1")]
        BitsV1,

        /// <summary> Anyone cheers in a specified channel. </summary>
        /// <remarks> Requires the <c>bits:read</c> scope. </remarks>
        [EnumMember(Value = "channel-bits-events-v2")]
        BitsV2,

        /// <summary> Message sent when a user earns a new Bits badge in a particular channel, 
        /// and chooses to share the notification with chat. </summary>
        /// <remarks> Requires the <c>bits:read</c> scope. </remarks>
        [EnumMember(Value = "channel-bits-badge-unlocks")]
        BitsBadgeUnlocks,

        /// <summary> A custom reward is redeemed in a channel. </summary>
        /// <remarks> Requires the <c>channel:read:redemptions</c> scope. </remarks>
        [EnumMember(Value = "channel-points-channel-v1")]
        ChannelPointRedemptions,

        /// <summary> Anyone subscribes (first month), resubscribes (subsequent months), 
        /// or gifts a subscription to a channel. </summary>
        /// <remarks> Requires the <c>channel:read:subscriptions</c> scope. </remarks>
        [EnumMember(Value = "channel-subscribe-events-v1")]
        ChannelSubscriptions,

        /// <summary> AutoMod flags a message as potentially inappropriate, 
        /// and when a moderator takes action on a message. </summary>
        /// <remarks> Requires the <c>channel:moderate</c> scope. </remarks>
        [EnumMember(Value = "automod-queue")]
        AutoModQueue,

        /// <summary> Examples of moderator actions are bans, unbans, timeouts, 
        /// deleting messages, changing chat mode (followers-only, subs-only), 
        /// changing AutoMod levels, and adding a mod. </summary>
        /// <remarks> Requires the <c>channel:moderate</c> scope. </remarks>
        [EnumMember(Value = "chat_moderator_actions")]
        ModeratorActions,

        /// <summary> The broadcaster or a moderator updates the low trust status 
        /// of a user, or a new message has been sent in chat by a potential ban 
        /// evader or a bans shared user. </summary>
        /// <remarks> Requires the <c>channel:moderate</c> scope. </remarks>
        [EnumMember(Value = "low-trust-users")]
        LowTrustUserStatus,

        /// <summary> A user’s message held by AutoMod has been approved or denied. </summary>
        /// <remarks> Requires the <c>chat:read</c> scope. </remarks>
        [EnumMember(Value = "user-moderation-notifications")]
        ModerationNotifications,

        /// <summary> Anyone whispers the specified user. </summary>
        /// <remarks> Requires the <c>whispers:read</c> scope. </remarks>
        [EnumMember(Value = "whispers")]
        Whispers
    }
}
