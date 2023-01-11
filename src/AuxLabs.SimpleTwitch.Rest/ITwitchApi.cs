using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Requests;
using RestEase;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Header("User-Agent", "Auxlabs (https://github.com/AuxLabs/SimpleTwitch)")]
    public interface ITwitchApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }
        [Header("Client-ID")]
        string ClientId { get; set; }

        // Ads

        [Post("channels/commercial")]
        Task<TwitchResponse<Commercial>> PostCommercialAsync([Body]PostChannelCommercialParams args);

        // Analytics

        [Get("analytics/extensions")]
        Task<TwitchResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync([QueryMap] GetExtensionAnalyticsParams args);
        [Get("analytics/games")]
        Task<TwitchResponse<GameAnalytic>> GetGameAnalyticsAsync([QueryMap] GetGameAnalyticsParams args);

        // Bits

        [Get("bits/leaderboard")]
        Task<TwitchResponse<BitsUser>> GetBitsLeaderboardAsync([QueryMap] GetBitsLeaderboardRequest args);
        [Get("bits/cheermotes")]
        Task<TwitchResponse<Cheermote>> GetCheermotesasync([Query("broadcaster_id")] string broadcasterId);
        [Get("extensions/transactions")]
        Task<TwitchResponse<ExtensionTransaction>> GetExtensionTransactionAsync([QueryMap] GetExtensionTransactionsRequest args);

        // Channels

        [Get("channels")]
        Task<Channel> GetChannelAsync([Query] object args);
        [Patch("channels")]
        Task ModifyChannelAsync([Query] object args);
        [Get("channels/editors")]
        Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync([Query] object args);

        // Channel Points

        [Post("channel_points/custom_rewards")]
        Task<object> CreateRewardsAsync([Query] object args);
        [Delete("channel_points/custom_rewards")]
        Task DeleteRewardAsync([Query] object args);
        [Get("channel_points/custom_rewards")]
        Task<TwitchResponse<object>> GetRewardsAsync([Query] object args);
        [Get("channel_points/custom_rewards/redemptions")]
        Task<object> GetRewardRedemptionAsync([Query] object args);
        [Patch("channel_points/custom_rewards")]
        Task<object> ModifyRewardAsync([Query] object args);
        [Patch("channel_points/custom_rewards/redemptions")]
        Task<object> ModifyRewardRedemptionAsync([Query] object args);

        // Charity

        [Post("charity/campaigns")]
        Task<object> GetCharityCampaignAsync([Query] object args);
        [Post("charity/donations")]
        Task<object> GetCharityCampaignDonationsAsync([Query] object args);


        // Chat

        [Get("chat/chatters")]
        Task<TwitchResponse<object>> GetChattersAsync([Query] object args);
        [Get("chat/emotes")]
        Task<TwitchResponse<object>> GetChannelEmotesAsync([Query] object args);
        [Get("chat/emotes/global")]
        Task<TwitchResponse<object>> GetGlobalEmotesAsync([Query] object args);
        [Get("chat/emotes/set")]
        Task<TwitchResponse<object>> GetEmoteSetsAsync([Query] object args);
        [Get("chat/badges")]
        Task<TwitchResponse<object>> GetChannelBadgesAsync([Query] object args);
        [Get("chat/badges/global")]
        Task<TwitchResponse<object>> GetGlobalBadgesAsync([Query] object args);
        [Get("chat/settings")]
        Task<TwitchResponse<object>> GetChatSettingsAsync([Query] object args);
        [Patch("chat/settings")]
        Task<TwitchResponse<object>> ModifyChatSettingsAsync([Query] object args);
        [Post("chat/announcements")]
        Task<TwitchResponse<object>> PostChatAnnouncementAsync([Query] object args);
        [Get("chat/color")]
        Task<TwitchResponse<object>> GetUserChatColorAsync([Query] string userId);
        [Put("chat/color")]
        Task<TwitchResponse<object>> ModifyUserChatColor([Query] object args);

        // Clips

        [Post("clips")]
        Task<TwitchResponse<object>> CreateClipAsync([Query] object args);
        [Get("clips")]
        Task<TwitchResponse<object>> GetClipsAsync([Query] object args);

        // Entitlements

        [Get("entitlements/codes")]
        Task<TwitchResponse<object>> GetCodeStatusAsync([Query] object args);
        [Get("entitlements/drops")]
        Task<TwitchResponse<object>> GetDropsStatusAsync([Query] object args);
        [Patch("entitlements/drops")]
        Task<TwitchResponse<object>> ModifyDropsStatusAsync([Query] object args);
        [Post("entitlements/codes")]
        Task<TwitchResponse<object>> RedeemCodeAsync([Query] object args);

        // Extensions

        [Get("extensions/configurations")]
        Task<TwitchResponse<object>> GetExtensionConfigurationAsync([Query] object args);
        [Put("extensions/configurations")]
        Task<TwitchResponse<object>> ModifyExtensionConfigurationAsync([Query] object args);
        [Put("extensions/required_configuration")]
        Task<TwitchResponse<object>> ModifyExtensionRequiredConfigurationAsync([Query] object args);
        [Post("extensions/pubsub")]
        Task<TwitchResponse<object>> PostExtensionPubsubMessageAsync([Query] object args);
        [Get("extensions/live")]
        Task<TwitchResponse<object>> GetExtensionLiveChannelsAsync([Query] object args);
        [Get("extensions/jwt/secrets")]
        Task<TwitchResponse<object>> GetExtensionSecretsAsync([Query] object args);
        [Post("extensions/jwt/secrets")]
        Task<TwitchResponse<object>> PostExtensionSecretsAsync([Query] object args);
        [Post("extensions/chat")]
        Task<TwitchResponse<object>> PostExtensionChatMessageAsync([Query] object args);
        [Get("extensions")]
        Task<TwitchResponse<object>> GetExtensionsAsync([Query] object args);
        [Get("extensions/released")]
        Task<TwitchResponse<object>> GetReleasedExtensionsAsync([Query] object args);
        [Get("bits/extensions")]
        Task<TwitchResponse<object>> GetExtensionBitsProductsAsync([Query] object args);
        [Put("bits/extensions")]
        Task<TwitchResponse<object>> ModifyExtensionBitsProductsAsync([Query] object args);

        // EventSub

        [Post("eventsub/subscriptions")]
        Task<TwitchResponse<object>> PostEventSubSubcriptionAsync([Query] object args);
        [Delete("eventsub/subscriptions")]
        Task<TwitchResponse<object>> DeleteEventSubSubcrptionAsync([Query] object args);
        [Get("eventsub/subscriptions")]
        Task<TwitchResponse<object>> GetEventSubSubcriptionAsync([Query] object args);

        // Games

        [Get("games/top")]
        Task<TwitchResponse<object>> GetTopGamesAsync([Query] object args);
        [Get("games")]
        Task<TwitchResponse<object>> GetGamesAsync([Query] object args);

        // Goals

        [Get("goals")]
        Task<TwitchResponse<object>> GetGoalsAsync([Query] object args);

        // Hype Train

        [Get("hypetrain/events")]
        Task<TwitchResponse<object>> GetHypetrainEventsAsync([Query] object args);

        // Moderation

        [Post("moderation/enforcements/status")]
        Task<TwitchResponse<object>> GetModerationStatusAsync([Query] object args);
        [Post("moderation/automod/message")]
        Task<TwitchResponse<object>> GetAutomodMessagesAsync([Query] object args);
        [Get("moderation/automod/settings")]
        Task<TwitchResponse<object>> GetAutomodSettingsAsync([Query] object args);
        [Put("moderation/automod/settings")]
        Task<TwitchResponse<object>> ModifyAutomodSettingsAsync([Query] object args);
        [Get("moderation/banned")]
        Task<TwitchResponse<object>> GetBannedUsersAsync([Query] object args);
        [Post("moderation/bans")]
        Task<TwitchResponse<object>> PostBanAsync([Query] object args);
        [Delete("moderation/bans")]
        Task<TwitchResponse<object>> DeleteBanAsync([Query] object args);
        [Get("moderation/blocked_terms")]
        Task<TwitchResponse<object>> GetBlockedTermsAsync([Query] object args);
        [Post("moderation/blocked_terms")]
        Task<TwitchResponse<object>> PostBlockedTermAsync([Query] object args);
        [Delete("moderation/blocked_term")]
        Task<TwitchResponse<object>> DeleteBlockedTermAsync([Query] object args);
        [Delete("moderation/chat")]
        Task<TwitchResponse<object>> DeleteChatMessagesAsync([Query] object args);
        [Get("moderation/moderators")]
        Task<TwitchResponse<object>> GetModeratorsAsync([Query] object args);
        [Post("moderation/moderators")]
        Task<TwitchResponse<object>> PostModeratorAsync([Query] object args);
        [Delete("moderation/moderators")]
        Task<TwitchResponse<object>> DeleteModeratorAsync([Query] object args);
        [Get("channels/vips")]
        Task<TwitchResponse<object>> GetVipsAsync([Query] object args);
        [Post("channels/vips")]
        Task<TwitchResponse<object>> PostVipAsync([Query] object args);
        [Delete("channels/vips")]
        Task<TwitchResponse<object>> DeleteVipAsync([Query] object args);
        [Put("moderation/shield_mode")]
        Task<TwitchResponse<object>> ModifyShieldModeAsync([Query] object args);
        [Get("moderation/shield_mode")]
        Task<TwitchResponse<object>> GetShieldModeAsync([Query] object args);

        // Polls

        [Get("polls")]
        Task<TwitchResponse<object>> GetPollAsync([Query] object args);
        [Post("polls")]
        Task<TwitchResponse<object>> PostPollAsync([Query] object args);
        [Patch("polls")]
        Task<TwitchResponse<object>> EndPollAsync([Query] object args);

        // Predictions

        [Get("predictions")]
        Task<TwitchResponse<object>> GetPredictionAsync([Query] object args);
        [Post("predictions")]
        Task<TwitchResponse<object>> PostPredictionAsync([Query] object args);
        [Patch("predictions")]
        Task<TwitchResponse<object>> EndPredictionaAsync([Query] object args);

        // Raids

        [Post("raids")]
        Task<TwitchResponse<object>> PostRaidAsync([Query] object args);
        [Delete("raids")]
        Task<TwitchResponse<object>> DeleteRaidAsync([Query] object args);

        // Schedule

        [Get("schedule")]
        Task<TwitchResponse<object>> GetScheduleAsync([Query] object args);
        [Get("schedule/icalendar")]
        Task<TwitchResponse<object>> GetCalendarAsync([Query] object args);
        [Patch("schedule/settings")]
        Task<TwitchResponse<object>> ModifyScheduleAsync([Query] object args);
        [Post("schedule/segment")]
        Task<TwitchResponse<object>> PostScheduleSegmentAsync([Query] object args);
        [Patch("schedule/segment")]
        Task<TwitchResponse<object>> ModifyScheduleSegmentAsync([Query] object args);
        [Delete("schedule/segment")]
        Task<TwitchResponse<object>> DeleteScheduleSegmentAsync([Query] object args);

        // Search

        [Get("search/categories")]
        Task<TwitchResponse<object>> GetCategoriesAsync([Query] object args);
        [Get("search/channels")]
        Task<TwitchResponse<object>> GetChannelsAsync([Query] object args);

        // Music

        [Get("soundtrack/current_track")]
        Task<TwitchResponse<object>> GetCurrentTrackAsync([Query] object args);
        [Get("soundtrack/playlist")]
        Task<TwitchResponse<object>> GetCurrentPlaylistAsync([Query] object args);
        [Get("soundtrack/playlists")]
        Task<TwitchResponse<object>> GetPlaylistsAsync([Query] object args);

        // Streams

        [Get("streams/key")]
        Task<TwitchResponse<object>> GetStreamKeyAsync([Query] object args);
        [Get("streams")]
        Task<TwitchResponse<object>> GetStreamsAsync([Query] object args);
        [Get("streams/followed")]
        Task<TwitchResponse<object>> GetFollowedStreamsAsync([Query] object args);
        [Post("streams/markers")]
        Task<TwitchResponse<object>> PostStreamMarkerAsync([Query] object args);
        [Get("streams/markers")]
        Task<TwitchResponse<object>> GetStreamMarkersAsync([Query] object args);

        // Subscriptions

        [Get("subscriptions")]
        Task<TwitchResponse<object>> GetSubscriptionsAsync([Query] object args);
        [Get("subscriptions/user")]
        Task<TwitchResponse<object>> GetSubscriberAsync([Query] object args);

        // Tags

        [Get("tags/streams")]
        Task<TwitchResponse<object>> GetTagsAsync([Query] object args);
        [Get("streams/tags")]
        Task<TwitchResponse<object>> GetTagsAsync([Query("broadcaster_id")] string id);
        [Put("streams/tags")]
        Task<TwitchResponse<object>> ModifyTagsAsync([Query] object args);

        // Teams

        [Get("teams/channel")]
        Task<TwitchResponse<object>> GetTeamsAsync([Query("broadcaster_id")] string id);
        [Get("teams")]
        Task<TwitchResponse<object>> GetTeamsAsync([Query] object args);

        // Users

        [Get("users")]
        Task<TwitchResponse<User>> GetUsersAsync([QueryMap] GetUsersParams args);
        [Put("users")]
        Task<TwitchResponse<User>> ModifyUserAsync([Query("description")] string description);
        [Get("users/follows")]
        Task<TwitchResponse<Follower>> GetFollowsAsync([Query] GetFollowsParams args);
        [Get("users/blocks")]
        Task<TwitchResponse<object>> GetBlocksAsync([Query] object args);
        [Put("users/blocks")]
        Task<TwitchResponse<object>> PostBlockAsync([Query] object args);
        [Delete("users/blocks")]
        Task<TwitchResponse<object>> DeleteBlockAsync([Query] object args);
        [Get("users/extensions/list")]
        Task<TwitchResponse<object>> GetUserExtensionsAsync([Query] object args);
        [Get("users/extensions")]
        Task<TwitchResponse<object>> GetActiveExtensionsAsync([Query] object args);
        [Put("users/extesions")]
        Task<TwitchResponse<object>> ModifyExtensionsAsync([Query] object args);

        // Videos

        [Get("videos")]
        Task<TwitchResponse<object>> GetVideosAsync([Query] object args);
        [Delete("videos")]
        Task<IEnumerable<string>> DeleteVideoAsync([Query] string id);

        // Whispers

        [Post("whispers")]
        Task PostWhisperAsync([Query("from_user_id")] string fromUserId, [Query("to_user_id")] string toUserId, [Body] string message);
    }
}
