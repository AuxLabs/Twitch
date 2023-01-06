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
        Task<TwitchResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync([Query]GetExtensionAnalyticsParams args);
        [Get("analytics/games")]
        Task<TwitchResponse<GameAnalytic>> GetGameAnalyticsAsync([Query]GetGameAnalyticsParams args);

        // Bits

        [Get("bits/leaderboard")]
        Task<TwitchResponse<BitsUser>> GetBitsLeaderboardAsync([Query]object args);
        [Get("bits/cheermotes")]
        Task<TwitchResponse<Cheermote>> GetCheermotesasync([Query] object args);
        [Get("extensions/transactions")]
        Task<TwitchResponse<ExtensionTransaction>> GetExtensionTransactionAsync([Query]object args);

        // Channels

        [Get("channels")]
        Task<Channel> GetChannelAsync([Query]object args);
        [Patch("channels")]
        Task ModifyChannelAsync([Query] object args);
        [Get("channels/editors")]
        Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync([Query] object args);

        // Channel Points

        [Post("channel_points/custom_rewards")]
        Task<object> CreateRewardsAsync([Query]object args);
        [Delete("channel_points/custom_rewards")]
        Task DeleteRewardAsync([Query] object args);
        [Get("channel_points/custom_rewards")]
        Task<TwitchResponse<object>> GetRewardsAsync([Query] object args);
        [Get("channel_points/custom_rewards/redemptions")]
        Task<object> GetRewardRedemptionAsync([Query]object args);
        [Patch("channel_points/custom_rewards")]
        Task<object> ModifyRewardAsync([Query] object args);
        [Patch("channel_points/custom_rewards/redemptions")]
        Task<object> ModifyRewardRedemptionAsync([Query] object args);

        // Chat

        [Get("chat/emotes")]
        Task<TwitchResponse<object>> GetChannelEmotesAsync([Query]object args);
        [Get("chat/emotes/global")]
        Task<TwitchResponse<object>> GetGlobalEmotesAsync([Query]object args);
        [Get("chat/emotes/set")]
        Task<TwitchResponse<object>> GetEmoteSetsAsync([Query]object args);
        [Get("chat/badges")]
        Task<TwitchResponse<object>> GetChannelBadgesAsync([Query]object args);
        [Get("chat/badges/global")]
        Task<TwitchResponse<object>> GetGlobalBadgesAsync([Query]object args);
        [Get("chat/settings")]
        Task<TwitchResponse<object>> GetChatSettingsAsync([Query]object args);
        [Patch("chat/settings")]
        Task<TwitchResponse<object>> ModifyChatSettingsAsync([Query]object args);
        [Post("chat/announcements")]
        Task<TwitchResponse<object>> PostChatAnnouncementAsync([Query] object args);
        [Get("chat/color")]
        Task<TwitchResponse<object>> GetUserChatColorAsync([Query]string userId);
        [Put("chat/color")]
        Task<TwitchResponse<object>> ModifyUserChatColor([Query] object args);

        // Clips

        [Post("clips")]
        Task<object> CreateClipAsync([Query] object args);
        [Get("clips")]
        Task<object> GetClipsAsync([Query] object args);

        // Entitlements

        [Get("entitlements/codes")]
        Task<object> GetCodeStatusAsync([Query] object args);
        [Get("entitlements/drops")]
        Task<object> GetDropsStatusAsync([Query] object args);
        [Patch("entitlements/drops")]
        Task<object> ModifyDropsStatusAsync([Query] object args);
        [Post("entitlements/codes")]
        Task<object> RedeemCodeAsync([Query] object args);

        // Extensions

        [Get("extensions/configurations")]
        Task<object> GetExtensionConfigurationAsync([Query] object args);
        [Put("extensions/configurations")]
        Task<object> ModifyExtensionConfigurationAsync([Query] object args);
        [Put("extensions/required_configuration")]
        Task<object> ModifyExtensionRequiredConfigurationAsync([Query] object args);
        [Post("extensions/pubsub")]
        Task<object> PostExtensionPubsubMessageAsync([Query] object args);
        [Get("extensions/live")]
        Task<object> GetExtensionLiveChannelsAsync([Query] object args);
        [Get("extensions/jwt/secrets")]
        Task<object> GetExtensionSecretsAsync([Query] object args);
        [Post("extensions/jwt/secrets")]
        Task<object> PostExtensionSecretsAsync([Query] object args);
        [Post("extensions/chat")]
        Task<object> PostExtensionChatMessageAsync([Query] object args);
        [Get("extensions")]
        Task<object> GetExtensionsAsync([Query] object args);
        [Get("extensions/released")]
        Task<object> GetReleasedExtensionsAsync([Query] object args);
        [Get("bits/extensions")]
        Task<object> GetExtensionBitsProductsAsync([Query] object args);
        [Put("bits/extensions")]
        Task<object> ModifyExtensionBitsProductsAsync([Query] object args);

        // EventSub

        [Post("eventsub/subscriptions")]
        Task<object> PostEventSubSubcriptionAsync([Query] object args);
        [Delete("eventsub/subscriptions")]
        Task<object> DeleteEventSubSubcrptionAsync([Query] object args);
        [Get("eventsub/subscriptions")]
        Task<object> GetEventSubSubcriptionAsync([Query] object args);

        // Games

        [Get("games/top")]
        Task<object> GetTopGamesAsync([Query] object args);
        [Get("games")]
        Task<object> GetGamesAsync([Query] object args);

        // Goals

        [Get("goals")]
        Task<object> GetGoalsAsync([Query] object args);

        // Hype Train

        [Get("hypetrain/events")]
        Task<object> GetHypetrainEventsAsync([Query] object args);

        // Moderation



        // polls
        // predictions
        // schedule
        // search
        // music
        // streams
        // subscriptions
        // tags
        // teams
        // users
        // whispers

        [Get("users")]
        Task<TwitchResponse<User>> GetUsersAsync([Query]GetUsersParams args);
    }
}
