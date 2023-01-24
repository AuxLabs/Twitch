using System.Runtime.Serialization;

namespace AuxLabs.SimpleTwitch.Chat
{
    public enum NoticeType
    {
        Unknown,

        [EnumMember(Value = "already_banned")]
        AlreadyBanned,
        [EnumMember(Value = "already_emote_only_off")]
        AlreadyEmoteOnlyOff,
        [EnumMember(Value = "already_emote_only_on")]
        AlreadyEmoteOnlyOn,
        [EnumMember(Value = "already_followers_off")]
        AlreadyFollowersOff,
        [EnumMember(Value = "already_followers_on")]
        AlreadyFollowersOn,
        [EnumMember(Value = "already_R9k_off")]
        AlreadyR9kOff,
        [EnumMember(Value = "already_R9k_on")]
        AlreadyR9kOn,
        [EnumMember(Value = "already_slow_off")]
        AlreadySlowOff,
        [EnumMember(Value = "already_slow_on")]
        AlreadySlowOn,
        [EnumMember(Value = "already_subs_off")]
        AlreadySubsOff,
        [EnumMember(Value = "already_subs_on")]
        AlreadySubsOn,

        [EnumMember(Value = "bad_ban_admin")]
        BadBanAdmin,
        [EnumMember(Value = "bad_ban_anon")]
        BadBanAnonymous,
        [EnumMember(Value = "bad_ban_broadcaster")]
        BadBanBroadcaster,
        [EnumMember(Value = "bad_ban_mod")]
        BadBanMod,
        [EnumMember(Value = "bad_ban_self")]
        BadBanSelf,
        [EnumMember(Value = "bad_ban_staff")]
        BadBanStaff,

        [EnumMember(Value = "bad_commercial_error")]
        BadCommercialError,

        [EnumMember(Value = "bad_delete_message_broadcaster")]
        BadDeleteMessageBroadcaster,
        [EnumMember(Value = "bad_delete_message_mod")]
        BadDeleteMessageModerator,

        [EnumMember(Value = "bad_mod_banned")]
        BadModBanned,
        [EnumMember(Value = "bad_mod_mod")]
        BadModAlreadyMod,

        [EnumMember(Value = "bad_slow_duration")]
        BadSlowDuration,

        [EnumMember(Value = "bad_timeout_admin")]
        BadTimeoutAdmin,
        [EnumMember(Value = "bad_timeout_anon")]
        BadTimeoutAnonymous,
        [EnumMember(Value = "bad_timeout_broadcaster")]
        BadTimeoutBroadcaster,
        [EnumMember(Value = "bad_timeout_duration")]
        BadTimeoutDuration,
        [EnumMember(Value = "bad_timeout_mod")]
        BadTimeoutModerator,
        [EnumMember(Value = "bad_timeout_self")]
        BadTimeoutSelf,
        [EnumMember(Value = "bad_timeout_staff")]
        BadTimeoutStaff,

        [EnumMember(Value = "bad_unban_no_ban")]
        BadUnbanNoBan,
        [EnumMember(Value = "bad_unmod_mod")]
        BadUnmodMod,

        [EnumMember(Value = "bad_vip_grantee_banned")]
        BadVipAlreadyBanned,
        [EnumMember(Value = "bad_vip_grantee_already_vip")]
        BadVipVip,
        [EnumMember(Value = "bad_vip_max_vips_reached")]
        BadVipMaxReached,
        [EnumMember(Value = "bad_vip_achievement_incomplete")]
        BadVipUnavailable,
        [EnumMember(Value = "bad_unvip_grantee_not_vip")]
        BadUnvipNotVip,

        [EnumMember(Value = "ban_success")]
        BanSuccess,
        [EnumMember(Value = "cmds_available")]
        CommandsAvailable,
        [EnumMember(Value = "color_changed")]
        ColorChanged,
        [EnumMember(Value = "commercial_success")]
        CommercialSuccess,
        [EnumMember(Value = "delete_message_success")]
        DeleteMessageSuccess,
        [EnumMember(Value = "delete_staff_message_success")]
        DeleteStaffMessageSuccess,

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

        [EnumMember(Value = "invalid_user")]
        InvalidUser,
        [EnumMember(Value = "mod_success")]
        ModSuccess,
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

        [EnumMember(Value = "no_help")]
        NoHelp,
        [EnumMember(Value = "no_mods")]
        NoMods,
        [EnumMember(Value = "no_vips")]
        NoVips,
        [EnumMember(Value = "no_permission")]
        NoPermission,

        [EnumMember(Value = "R9k_off")]
        R9kOff,
        [EnumMember(Value = "R9k_on")]
        R9kOn,

        [EnumMember(Value = "raid_error_already_raiding")]
        RaidErrorAlreadyRaiding,
        [EnumMember(Value = "raid_error_forbidden")]
        RaidErrorForbidden,
        [EnumMember(Value = "raid_error_self")]
        RaidErrorSelf,
        [EnumMember(Value = "raid_error_too_many_viewers")]
        RaidErrorMaxViewers,
        [EnumMember(Value = "raid_error_unexpected")]
        RaidErrorUnexpected,
        [EnumMember(Value = "raid_notice_mature")]
        RaidNoticeMature,
        [EnumMember(Value = "raid_notice_restricted_chat")]
        RaidNoticeRestricted,

        [EnumMember(Value = "room_mods")]
        RoomMods,

        [EnumMember(Value = "slow_off")]
        SlowOff,
        [EnumMember(Value = "slow_on")]
        SlowOn,
        [EnumMember(Value = "subs_off")]
        SubsOff,
        [EnumMember(Value = "subs_on")]
        SubsOn,

        [EnumMember(Value = "timeout_no_timeout")]
        TimeoutNone,
        [EnumMember(Value = "timeout_success")]
        TimeoutSuccess,

        [EnumMember(Value = "tos_ban")]
        TOSBan,
        [EnumMember(Value = "turbo_only_color")]
        TurboOnlyColor,
        [EnumMember(Value = "unavailable_command")]
        CommandUnavailable,

        [EnumMember(Value = "unban_success")]
        UnbanSuccess,
        [EnumMember(Value = "unmod_success")]
        UnmodSuccess,
        [EnumMember(Value = "unraid_error_no_active_raid")]
        UnraidErrorNotActive,
        [EnumMember(Value = "unraid_error_unexpected")]
        UnraidErrorUnexpected,
        [EnumMember(Value = "unraid_success")]
        UnraidSuccess,
        [EnumMember(Value = "unrecognized_cmd")]
        CommandNotRecognized,
        [EnumMember(Value = "untimeout_banned")]
        UntimeoutBanned,
        [EnumMember(Value = "untimeout_success")]
        UntimeoutSuccess,
        [EnumMember(Value = "unvip_success")]
        UnvipSuccess,

        [EnumMember(Value = "usage_ban")]
        UsageBan,
        [EnumMember(Value = "usage_clear")]
        UsageClear,
        [EnumMember(Value = "usage_color")]
        UsageColor,
        [EnumMember(Value = "usage_commercial")]
        UsageCommercial,
        [EnumMember(Value = "usage_disconnect")]
        UsageDisconnect,
        [EnumMember(Value = "usage_delete")]
        UsageDelete,
        [EnumMember(Value = "usage_emote_only_off")]
        UsageEmoteOnlyOff,
        [EnumMember(Value = "usage_emote_only_on")]
        UsageEmoteOnlyOn,
        [EnumMember(Value = "usage_followers_off")]
        UsageFollowersOff,
        [EnumMember(Value = "usage_followers_on")]
        UsageFollowersOn,
        [EnumMember(Value = "usage_help")]
        UsageHelp,
        [EnumMember(Value = "usage_marker")]
        UsageMarker,
        [EnumMember(Value = "usage_me")]
        UsageMe,
        [EnumMember(Value = "usage_mod")]
        UsageMod,
        [EnumMember(Value = "usage_mods")]
        UsageMods,
        [EnumMember(Value = "usage_R9k_off")]
        UsageR9kOff,
        [EnumMember(Value = "usage_R9k_on")]
        UsageR9kOn,
        [EnumMember(Value = "usage_raid")]
        UsageRaid,
        [EnumMember(Value = "usage_slow_off")]
        UsageSlowOff,
        [EnumMember(Value = "usage_slow_on")]
        UsageSlowOn,
        [EnumMember(Value = "usage_subs_off")]
        UsageSubsOff,
        [EnumMember(Value = "usage_subs_on")]
        UsageSubsOn,
        [EnumMember(Value = "usage_timeout")]
        UsageTimeout,
        [EnumMember(Value = "usage_unban")]
        UsageUnban,
        [EnumMember(Value = "usage_unmod")]
        UsageUnmod,
        [EnumMember(Value = "usage_unraid")]
        UsageUnraid,
        [EnumMember(Value = "usage_untimeout")]
        UsageUntimeout,
        [EnumMember(Value = "usage_unvip")]
        UsageUnvip,
        [EnumMember(Value = "usage_user")]
        UsageUser,
        [EnumMember(Value = "usage_vip")]
        UsageVip,
        [EnumMember(Value = "usage_vips")]
        UsageVips,
        [EnumMember(Value = "usage_whisper")]
        UsageWhisper,

        [EnumMember(Value = "vip_success")]
        VipSuccess,
        [EnumMember(Value = "vips_success")]
        VipsSuccess,

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
