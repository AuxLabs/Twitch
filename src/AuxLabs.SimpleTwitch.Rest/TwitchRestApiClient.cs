using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchRestApiClient : ITwitchApi, IDisposable
    {
        private readonly ITwitchApi _api;
        private bool _disposed = false;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public string ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchRestApiClient(IRateLimiter rateLimiter = null)
            : this(TwitchConstants.RestApiUrl, rateLimiter) { }
        public TwitchRestApiClient(string url, IRateLimiter rateLimiter = null)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            _api = RestClient.For<ITwitchApi>(new TwitchRequester(httpClient, rateLimiter));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _api.Dispose();
                
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        #region Ads

        /// <inheritdoc cref="PostCommercialAsync(PostChannelCommercialArgs)"/>
        public Task<TwitchResponse<Commercial>> PostCommercialAsync(Action<PostChannelCommercialArgs> action)
            => PostCommercialAsync(action.InvokeReturn());
        public Task<TwitchResponse<Commercial>> PostCommercialAsync(PostChannelCommercialArgs args)
            => _api.PostCommercialAsync(args);

        #endregion
        #region Analytics

        /// <inheritdoc cref="GetExtensionAnalyticsAsync(GetExtensionAnalyticsArgs)"/>
        public Task<TwitchResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync(Action<GetExtensionAnalyticsArgs> action)
            => GetExtensionAnalyticsAsync(action.InvokeReturn());
        public Task<TwitchResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsArgs args)
            => _api.GetExtensionAnalyticsAsync(args);

        /// <inheritdoc cref="GetGameAnalyticsAsync(GetGameAnalyticsArgs)"/>
        public Task<TwitchResponse<GameAnalytic>> GetGameAnalyticsAsync(Action<GetGameAnalyticsArgs> action)
            => GetGameAnalyticsAsync(action.InvokeReturn());
        public Task<TwitchResponse<GameAnalytic>> GetGameAnalyticsAsync(GetGameAnalyticsArgs args)
            => _api.GetGameAnalyticsAsync(args);

        /// <inheritdoc cref="GetBitsLeaderboardAsync(GetBitsLeaderboardArgs)"/>
        public Task<TwitchResponse<BitsUser>> GetBitsLeaderboardAsync(Action<GetBitsLeaderboardArgs> action)
            => GetBitsLeaderboardAsync(action.InvokeReturn());
        public Task<TwitchResponse<BitsUser>> GetBitsLeaderboardAsync(GetBitsLeaderboardArgs args)
            => _api.GetBitsLeaderboardAsync(args);

        #endregion
        #region Bits

        public Task<TwitchResponse<Cheermote>> GetCheermotesAsync(string broadcasterId)
            => _api.GetCheermotesAsync(broadcasterId);

        /// <inheritdoc cref="GetExtensionTransactionAsync(GetExtensionTransactionsArgs)"/>
        public Task<TwitchResponse<ExtensionTransaction>> GetExtensionTransactionAsync(Action<GetExtensionTransactionsArgs> action)
            => GetExtensionTransactionAsync(action.InvokeReturn());
        public Task<TwitchResponse<ExtensionTransaction>> GetExtensionTransactionAsync(GetExtensionTransactionsArgs args)
            => _api.GetExtensionTransactionAsync(args);

        #endregion
        #region Channels

        /// <inheritdoc cref="GetChannelsAsync(GetChannelsArgs)"/>
        public Task<TwitchResponse<Channel>> GetChannelsAsync(params string[] broadcasterIds)
            => GetChannelsAsync(new GetChannelsArgs(broadcasterIds));
        /// <inheritdoc cref="GetChannelsAsync(GetChannelsArgs)"/>
        public Task<TwitchResponse<Channel>> GetChannelsAsync(Action<GetChannelsArgs> action)
            => GetChannelsAsync(action.InvokeReturn());
        public Task<TwitchResponse<Channel>> GetChannelsAsync(GetChannelsArgs args)
            => _api.GetChannelsAsync(args);

        /// <inheritdoc cref="ModifyChannelAsync(string, ModifyChannelArgs)"/>
        public Task ModifyChannelAsync(string broadcasterId, Action<ModifyChannelArgs> action)
            => _api.ModifyChannelAsync(broadcasterId, action.InvokeReturn());
        public Task ModifyChannelAsync(string broadcasterId, ModifyChannelArgs args)
            => _api.ModifyChannelAsync(broadcasterId, args);

        public Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync(string broadcasterId)
            => _api.GetChannelEditorsAsync(broadcasterId);

        #endregion
        #region Channel Points

        /// <inheritdoc cref="CreateRewardsAsync(string, PostRewardArgs)"/>
        public Task<TwitchResponse<Reward>> CreateRewardsAsync(string broadcasterId, Action<PostRewardArgs> action)
            => _api.CreateRewardsAsync(broadcasterId, action.InvokeReturn());
        public Task<TwitchResponse<Reward>> CreateRewardsAsync(string broadcasterId, PostRewardArgs args)
            => _api.CreateRewardsAsync(broadcasterId, args);

        public Task DeleteRewardAsync(string broadcasterId, string customRewardId)
            => _api.DeleteRewardAsync(broadcasterId, customRewardId);

        /// <inheritdoc cref="GetRewardsAsync(GetRewardArgs)"/>
        public Task<TwitchResponse<Reward>> GetRewardsAsync(Action<GetRewardArgs> action)
            => _api.GetRewardsAsync(action.InvokeReturn());
        public Task<TwitchResponse<Reward>> GetRewardsAsync(GetRewardArgs args)
            => _api.GetRewardsAsync(args);

        /// <inheritdoc cref="GetRewardRedemptionAsync(GetRewardRedemptionsArgs)"/>
        public Task<TwitchResponse<Redemption>> GetRewardRedemptionAsync(Action<GetRewardRedemptionsArgs> action)
            => GetRewardRedemptionAsync(action.InvokeReturn());
        public Task<TwitchResponse<Redemption>> GetRewardRedemptionAsync(GetRewardRedemptionsArgs args)
            => _api.GetRewardRedemptionAsync(args);

        public Task<object> ModifyRewardAsync(object args)
            => _api.ModifyRewardAsync(args);
        public Task<object> ModifyRewardRedemptionAsync(object args)
            => _api.ModifyRewardRedemptionAsync(args);

        #endregion

        public Task<object> GetCharityCampaignAsync(object args)
            => _api.GetCharityCampaignAsync(args);
        public Task<object> GetCharityCampaignDonationsAsync(object args)
            => _api.GetCharityCampaignDonationsAsync(args);

        public Task<TwitchResponse<object>> GetChattersAsync(object args)
            => _api.GetChattersAsync(args);
        public Task<TwitchResponse<object>> GetChannelEmotesAsync(object args)
            => _api.GetChannelEmotesAsync(args);
        public Task<TwitchResponse<object>> GetGlobalEmotesAsync(object args)
            => _api.GetGlobalEmotesAsync(args);
        public Task<TwitchResponse<object>> GetEmoteSetsAsync(object args)
            => _api.GetEmoteSetsAsync(args);
        public Task<TwitchResponse<object>> GetChannelBadgesAsync(object args)
            => _api.GetChannelBadgesAsync(args);
        public Task<TwitchResponse<object>> GetGlobalBadgesAsync(object args)
            => _api.GetGlobalBadgesAsync(args);
        public Task<TwitchResponse<object>> GetChatSettingsAsync(object args)
            => _api.GetChatSettingsAsync(args);
        public Task<TwitchResponse<object>> ModifyChatSettingsAsync(object args)
            => _api.ModifyChatSettingsAsync(args);
        public Task<TwitchResponse<object>> PostChatAnnouncementAsync(object args)
            => _api.PostChatAnnouncementAsync(args);
        public Task<TwitchResponse<object>> GetUserChatColorAsync(string userId)
            => _api.GetUserChatColorAsync(userId);
        public Task<TwitchResponse<object>> ModifyUserChatColor(object args)
            => _api.ModifyUserChatColor(args);

        public Task<TwitchResponse<object>> CreateClipAsync(object args)
            => _api.CreateClipAsync(args);
        public Task<TwitchResponse<object>> GetClipsAsync(object args)
            => _api.GetClipsAsync(args);

        public Task<TwitchResponse<object>> GetCodeStatusAsync(object args)
            => _api.GetCodeStatusAsync(args);
        public Task<TwitchResponse<object>> GetDropsStatusAsync(object args)
            => _api.GetDropsStatusAsync(args);
        public Task<TwitchResponse<object>> ModifyDropsStatusAsync(object args)
            => _api.ModifyDropsStatusAsync(args);
        public Task<TwitchResponse<object>> RedeemCodeAsync(object args)
            => _api.RedeemCodeAsync(args);

        public Task<TwitchResponse<object>> GetExtensionConfigurationAsync(object args)
            => _api.GetExtensionConfigurationAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionConfigurationAsync(object args)
            => _api.ModifyExtensionConfigurationAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionRequiredConfigurationAsync(object args)
            => _api.ModifyExtensionRequiredConfigurationAsync(args);
        public Task<TwitchResponse<object>> PostExtensionPubsubMessageAsync(object args)
            => _api.PostExtensionPubsubMessageAsync(args);
        public Task<TwitchResponse<object>> GetExtensionLiveChannelsAsync(object args)
            => _api.GetExtensionLiveChannelsAsync(args);
        public Task<TwitchResponse<object>> GetExtensionSecretsAsync(object args)
            => _api.GetExtensionSecretsAsync(args);
        public Task<TwitchResponse<object>> PostExtensionSecretsAsync(object args)
            => _api.PostExtensionSecretsAsync(args);
        public Task<TwitchResponse<object>> PostExtensionChatMessageAsync(object args)
            => _api.PostExtensionChatMessageAsync(args);
        public Task<TwitchResponse<object>> GetExtensionsAsync(object args)
            => _api.GetExtensionsAsync(args);
        public Task<TwitchResponse<object>> GetReleasedExtensionsAsync(object args)
            => _api.GetReleasedExtensionsAsync(args);
        public Task<TwitchResponse<object>> GetExtensionBitsProductsAsync(object args)
            => _api.GetExtensionBitsProductsAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionBitsProductsAsync(object args)
            => _api.ModifyExtensionBitsProductsAsync(args);

        public Task<TwitchResponse<object>> PostEventSubSubcriptionAsync(object args)
            => _api.PostEventSubSubcriptionAsync(args);
        public Task<TwitchResponse<object>> DeleteEventSubSubcrptionAsync(object args)
            => _api.DeleteEventSubSubcrptionAsync(args);
        public Task<TwitchResponse<object>> GetEventSubSubcriptionAsync(object args)
            => _api.GetEventSubSubcriptionAsync(args);

        public Task<TwitchResponse<object>> GetTopGamesAsync(object args)
            => _api.GetTopGamesAsync(args);
        public Task<TwitchResponse<object>> GetGamesAsync(object args)
            => _api.GetGamesAsync(args);

        public Task<TwitchResponse<object>> GetGoalsAsync(object args)
            => _api.GetGoalsAsync(args);

        public Task<TwitchResponse<object>> GetHypetrainEventsAsync(object args)
            => _api.GetHypetrainEventsAsync(args);

        public Task<TwitchResponse<object>> GetModerationStatusAsync(object args)
            => _api.GetModerationStatusAsync(args);
        public Task<TwitchResponse<object>> GetAutomodMessagesAsync(object args)
            => _api.GetAutomodMessagesAsync(args);
        public Task<TwitchResponse<object>> GetAutomodSettingsAsync(object args)
            => _api.GetAutomodSettingsAsync(args);
        public Task<TwitchResponse<object>> ModifyAutomodSettingsAsync(object args)
            => _api.ModifyAutomodSettingsAsync(args);
        public Task<TwitchResponse<object>> GetBannedUsersAsync(object args)
            => _api.GetBannedUsersAsync(args);
        public Task<TwitchResponse<object>> PostBanAsync(object args)
            => _api.PostBanAsync(args);
        public Task<TwitchResponse<object>> DeleteBanAsync(object args)
            => _api.DeleteBanAsync(args);
        public Task<TwitchResponse<object>> GetBlockedTermsAsync(object args)
            => _api.GetBlockedTermsAsync(args);
        public Task<TwitchResponse<object>> PostBlockedTermAsync(object args)
            => _api.PostBlockedTermAsync(args);
        public Task<TwitchResponse<object>> DeleteBlockedTermAsync(object args)
            => _api.DeleteBlockedTermAsync(args);
        public Task<TwitchResponse<object>> DeleteChatMessagesAsync(object args)
            => _api.DeleteChatMessagesAsync(args);
        public Task<TwitchResponse<object>> GetModeratorsAsync(object args)
            => _api.GetModeratorsAsync(args);
        public Task<TwitchResponse<object>> PostModeratorAsync(object args)
            => _api.PostModeratorAsync(args);
        public Task<TwitchResponse<object>> DeleteModeratorAsync(object args)
            => _api.DeleteModeratorAsync(args);
        public Task<TwitchResponse<object>> GetVipsAsync(object args)
            => _api.GetVipsAsync(args);
        public Task<TwitchResponse<object>> PostVipAsync(object args)
            => _api.PostVipAsync(args);
        public Task<TwitchResponse<object>> DeleteVipAsync(object args)
            => _api.DeleteVipAsync(args);
        public Task<TwitchResponse<object>> ModifyShieldModeAsync(object args)
            => _api.ModifyShieldModeAsync(args);
        public Task<TwitchResponse<object>> GetShieldModeAsync(object args)
            => _api.GetShieldModeAsync(args);

        public Task<TwitchResponse<object>> GetPollAsync(object args)
            => _api.GetPollAsync(args);
        public Task<TwitchResponse<object>> PostPollAsync(object args)
            => _api.PostPollAsync(args);
        public Task<TwitchResponse<object>> EndPollAsync(object args)
            => _api.EndPollAsync(args);

        public Task<TwitchResponse<object>> GetPredictionAsync(object args)
            => _api.GetPredictionAsync(args);
        public Task<TwitchResponse<object>> PostPredictionAsync(object args)
            => _api.PostPredictionAsync(args);
        public Task<TwitchResponse<object>> EndPredictionaAsync(object args)
            => _api.EndPredictionaAsync(args);

        public Task<TwitchResponse<object>> PostRaidAsync(object args)
            => _api.PostRaidAsync(args);
        public Task<TwitchResponse<object>> DeleteRaidAsync(object args)
            => _api.DeleteRaidAsync(args);

        public Task<TwitchResponse<object>> GetScheduleAsync(object args)
            => _api.GetScheduleAsync(args);
        public Task<TwitchResponse<object>> GetCalendarAsync(object args)
            => _api.GetCalendarAsync(args);

        public Task<TwitchResponse<object>> ModifyScheduleAsync(object args)
            => _api.ModifyScheduleAsync(args);
        public Task<TwitchResponse<object>> PostScheduleSegmentAsync(object args)
            => _api.PostScheduleSegmentAsync(args);
        public Task<TwitchResponse<object>> ModifyScheduleSegmentAsync(object args)
            => _api.ModifyScheduleSegmentAsync(args);
        public Task<TwitchResponse<object>> DeleteScheduleSegmentAsync(object args)
            => _api.DeleteScheduleSegmentAsync(args);

        public Task<TwitchResponse<object>> SearchCategoriesAsync(object args)
            => _api.SearchCategoriesAsync(args);
        public Task<TwitchResponse<object>> SearchChannelsAsync(object args)
            => _api.SearchChannelsAsync(args);

        public Task<TwitchResponse<object>> GetCurrentTrackAsync(object args)
            => _api.GetCurrentTrackAsync(args);
        public Task<TwitchResponse<object>> GetCurrentPlaylistAsync(object args)
            => _api.GetCurrentPlaylistAsync(args);
        public Task<TwitchResponse<object>> GetPlaylistsAsync(object args)
            => _api.GetPlaylistsAsync(args);

        public Task<TwitchResponse<object>> GetStreamKeyAsync(object args)
            => _api.GetStreamKeyAsync(args);
        public Task<TwitchResponse<object>> GetStreamsAsync(object args)
            => _api.GetStreamsAsync(args);
        public Task<TwitchResponse<object>> GetFollowedStreamsAsync(object args)
            => _api.GetFollowedStreamsAsync(args);
        public Task<TwitchResponse<object>> PostStreamMarkerAsync(object args)
            => _api.PostStreamMarkerAsync(args);
        public Task<TwitchResponse<object>> GetStreamMarkersAsync(object args)
            => _api.GetStreamMarkersAsync(args);

        public Task<TwitchResponse<object>> GetSubscriptionsAsync(object args)
            => _api.GetSubscriptionsAsync(args);
        public Task<TwitchResponse<object>> GetSubscriberAsync(object args)
            => _api.GetSubscriberAsync(args);

        public Task<TwitchResponse<object>> GetTagsAsync(object args)
            => _api.GetTagsAsync(args);

        public Task<TwitchResponse<object>> GetTagsAsync(string id)
            => _api.GetTagsAsync(id);
        public Task<TwitchResponse<object>> ModifyTagsAsync(object args)
            => _api.ModifyTagsAsync(args);

        public Task<TwitchResponse<object>> GetTeamsAsync(string id)
            => _api.GetTeamsAsync(id);
        public Task<TwitchResponse<object>> GetTeamsAsync(object args)
            => _api.GetTeamsAsync(args);

        public Task<TwitchResponse<User>> GetUsersAsync(GetUsersArgs args)
            => _api.GetUsersAsync(args);
        public Task<TwitchResponse<User>> GetUsersAsync(Action<GetUsersArgs> action)
            => GetUsersAsync(action.InvokeReturn());
        public Task<TwitchResponse<User>> ModifyUserAsync(string description)
            => _api.ModifyUserAsync(description);
        public Task<TwitchResponse<Follower>> GetFollowsAsync(GetFollowsArgs args)
            => _api.GetFollowsAsync(args);
        public Task<TwitchResponse<object>> GetBlocksAsync(object args)
            => _api.GetBlocksAsync(args);
        public Task<TwitchResponse<object>> PostBlockAsync(object args)
            => _api.PostBlockAsync(args);
        public Task<TwitchResponse<object>> DeleteBlockAsync(object args)
            => _api.DeleteBlockAsync(args);

        public Task<TwitchResponse<object>> GetUserExtensionsAsync(object args)
            => _api.GetUserExtensionsAsync(args);
        public Task<TwitchResponse<object>> GetActiveExtensionsAsync(object args)
            => _api.GetActiveExtensionsAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionsAsync(object args)
            => _api.ModifyExtensionsAsync(args);

        public Task<TwitchResponse<object>> GetVideosAsync(object args)
            => _api.GetVideosAsync(args);
        public Task<IEnumerable<string>> DeleteVideoAsync(string id)
            => _api.DeleteVideoAsync(id);

        public Task PostWhisperAsync(string fromUserId, string toUserId, string message)
            => _api.PostWhisperAsync(fromUserId, toUserId, message);
    }
}
