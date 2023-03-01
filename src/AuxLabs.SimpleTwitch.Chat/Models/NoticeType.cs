using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat
{
    public enum NoticeType
    {
        Unknown,

        [EnumMember(Value = "color_changed")]
        ColorChanged,
        [EnumMember(Value = "tos_ban")]
        TOSBan,

        [EnumMember(Value = "emote_only_off")]
        EmoteOnlyOff,
        [EnumMember(Value = "emote_only_on")]
        EmoteOnlyOn,
        [EnumMember(Value = "followers_off")]
        FollowersOff,
        [EnumMember(Value = "followers_on")]
        FollowersOn,
        [EnumMember(Value = "followers_on_zero")]
        FollowersOnZero,
        [EnumMember(Value = "R9k_off")]
        R9kOff,
        [EnumMember(Value = "R9k_on")]
        R9kOn,
        [EnumMember(Value = "slow_off")]
        SlowOff,
        [EnumMember(Value = "slow_on")]
        SlowOn,
        [EnumMember(Value = "subs_off")]
        SubsOff,
        [EnumMember(Value = "subs_on")]
        SubsOn,

        [EnumMember(Value = "msg_banned")]
        MessageBanned,
        [EnumMember(Value = "msg_bad_characters")]
        MessageBadCharacters,
        [EnumMember(Value = "msg_channel_blocked")]
        MessageChannelBlocked,
        [EnumMember(Value = "msg_channel_suspended")]
        MessageChannelSuspended,
        [EnumMember(Value = "msg_duplicate")]
        MessageDuplicate,
        [EnumMember(Value = "msg_emoteonly")]
        MessageEmoteOnly,
        [EnumMember(Value = "msg_followersonly")]
        MessageFollowersOnly,
        [EnumMember(Value = "msg_followersonly_followed")]
        MessageFollowersOnlyFollowed,
        [EnumMember(Value = "msg_followersonly_zero")]
        MessageFollowersOnlyZero,
        [EnumMember(Value = "msg_R9k")]
        MessageR9k,
        [EnumMember(Value = "msg_ratelimit")]
        MessageRatelimited,
        [EnumMember(Value = "msg_rejected")]
        MessageRejected,
        [EnumMember(Value = "msg_rejected_mandatory")]
        MessageRejectedMandatory,
        [EnumMember(Value = "msg_requires_verified_phone_number")]
        MessageRequiresVerifiedPhone,
        [EnumMember(Value = "msg_slowmode")]
        MessageSlowmode,
        [EnumMember(Value = "msg_subsonly")]
        MessageSubsOnly,
        [EnumMember(Value = "msg_suspended")]
        MessageSuspended,
        [EnumMember(Value = "msg_timedout")]
        MessageTimedout,
        [EnumMember(Value = "msg_verified_email")]
        MessageRequiresVerifiedEmail,

        [EnumMember(Value = "whisper_banned")]
        WhisperBanned,
        [EnumMember(Value = "whisper_banned_recipient")]
        WhisperBannedRecipient,
        [EnumMember(Value = "whisper_invalid_login")]
        WhisperInvalidLogin,
        [EnumMember(Value = "whisper_invalid_self")]
        WhisperInvalidSelf,
        [EnumMember(Value = "whisper_limit_per_min")]
        WhisperRatelimitedMinute,
        [EnumMember(Value = "whisper_limit_per_sec")]
        WhisperRatelimitedSecond,
        [EnumMember(Value = "whisper_restricted")]
        WhisperRestricted,
        [EnumMember(Value = "whisper_restricted_recipient")]
        WhisperRestrictedRecipient
    }
}
