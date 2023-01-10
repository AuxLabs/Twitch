using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Requests;
using RestEase;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchRestApiClient : ITwitchApi, IDisposable
    {
        private readonly ITwitchApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public string ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchRestApiClient()
            : this(TwitchConstants.BaseUrl) { }
        public TwitchRestApiClient(string baseUrl)
            : this(new HttpClient { BaseAddress = new Uri(baseUrl) }) { }
        public TwitchRestApiClient(HttpClient httpClient)
        {
            _api = new RestClient(httpClient)
            {
                RequestBodySerializer = new Net.JsonBodySerializer(),
                ResponseDeserializer = new Net.JsonResponseDeserializer(),
                RequestQueryParamSerializer = new Net.JsonQueryParamSerializer(),
            }.For<ITwitchApi>();
        }

        public void Dispose() => _api.Dispose();

        public Task<TwitchResponse<Commercial>> PostCommercialAsync([Body] PostChannelCommercialParams args)
            => _api.PostCommercialAsync(args);

        public Task<TwitchResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync([Query] GetExtensionAnalyticsParams args)
            => _api.GetExtensionAnalyticsAsync(args);
        public Task<TwitchResponse<GameAnalytic>> GetGameAnalyticsAsync([Query] GetGameAnalyticsParams args)
            => _api.GetGameAnalyticsAsync(args);
        public Task<TwitchResponse<BitsUser>> GetBitsLeaderboardAsync([Query] GetBitsLeaderboardRequest args)
            => _api.GetBitsLeaderboardAsync(args);

        public Task<TwitchResponse<Cheermote>> GetCheermotesasync([Query("broadcaster_id")] string broadcasterId)
            => _api.GetCheermotesasync(broadcasterId);
        public Task<TwitchResponse<ExtensionTransaction>> GetExtensionTransactionAsync([Query] GetExtensionTransactionsRequest args)
            => _api.GetExtensionTransactionAsync(args);

        public Task<Channel> GetChannelAsync([Query] object args)
            => _api.GetChannelAsync(args);
        public Task ModifyChannelAsync([Query] object args)
            => _api.ModifyChannelAsync(args);
        public Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync([Query] object args)
            => _api.GetChannelEditorsAsync(args);

        public Task<object> CreateRewardsAsync([Query] object args)
            => _api.CreateRewardsAsync(args);
        public Task DeleteRewardAsync([Query] object args)
            => _api.DeleteRewardAsync(args);
        public Task<TwitchResponse<object>> GetRewardsAsync([Query] object args)
            => _api.GetRewardsAsync(args);
        public Task<object> GetRewardRedemptionAsync([Query] object args)
            => _api.GetRewardRedemptionAsync(args);
        public Task<object> ModifyRewardAsync([Query] object args)
            => _api.ModifyRewardAsync(args);
        public Task<object> ModifyRewardRedemptionAsync([Query] object args)
            => _api.ModifyRewardRedemptionAsync(args);

        public Task<object> GetCharityCampaignAsync([Query] object args)
            => _api.GetCharityCampaignAsync(args);
        public Task<object> GetCharityCampaignDonationsAsync([Query] object args)
            => _api.GetCharityCampaignDonationsAsync(args);

        public Task<TwitchResponse<object>> GetChattersAsync([Query] object args)
            => _api.GetChattersAsync(args);
        public Task<TwitchResponse<object>> GetChannelEmotesAsync([Query] object args)
            => _api.GetChannelEmotesAsync(args);
        public Task<TwitchResponse<object>> GetGlobalEmotesAsync([Query] object args)
            => _api.GetGlobalEmotesAsync(args);
        public Task<TwitchResponse<object>> GetEmoteSetsAsync([Query] object args)
            => _api.GetEmoteSetsAsync(args);
        public Task<TwitchResponse<object>> GetChannelBadgesAsync([Query] object args)
            => _api.GetChannelBadgesAsync(args);
        public Task<TwitchResponse<object>> GetGlobalBadgesAsync([Query] object args)
            => _api.GetGlobalBadgesAsync(args);
        public Task<TwitchResponse<object>> GetChatSettingsAsync([Query] object args)
            => _api.GetChatSettingsAsync(args);
        public Task<TwitchResponse<object>> ModifyChatSettingsAsync([Query] object args)
            => _api.ModifyChatSettingsAsync(args);
        public Task<TwitchResponse<object>> PostChatAnnouncementAsync([Query] object args)
            => _api.PostChatAnnouncementAsync(args);
        public Task<TwitchResponse<object>> GetUserChatColorAsync([Query] string userId)
            => _api.GetUserChatColorAsync(userId);
        public Task<TwitchResponse<object>> ModifyUserChatColor([Query] object args)
            => _api.ModifyUserChatColor(args);

        public Task<TwitchResponse<object>> CreateClipAsync([Query] object args)
            => _api.CreateClipAsync(args);
        public Task<TwitchResponse<object>> GetClipsAsync([Query] object args)
            => _api.GetClipsAsync(args);

        public Task<TwitchResponse<object>> GetCodeStatusAsync([Query] object args)
            => _api.GetCodeStatusAsync(args);
        public Task<TwitchResponse<object>> GetDropsStatusAsync([Query] object args)
            => _api.GetDropsStatusAsync(args);
        public Task<TwitchResponse<object>> ModifyDropsStatusAsync([Query] object args)
            => _api.ModifyDropsStatusAsync(args);
        public Task<TwitchResponse<object>> RedeemCodeAsync([Query] object args)
            => _api.RedeemCodeAsync(args);

        public Task<TwitchResponse<object>> GetExtensionConfigurationAsync([Query] object args)
            => _api.GetExtensionConfigurationAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionConfigurationAsync([Query] object args)
            => _api.ModifyExtensionConfigurationAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionRequiredConfigurationAsync([Query] object args)
            => _api.ModifyExtensionRequiredConfigurationAsync(args);
        public Task<TwitchResponse<object>> PostExtensionPubsubMessageAsync([Query] object args)
            => _api.PostExtensionPubsubMessageAsync(args);
        public Task<TwitchResponse<object>> GetExtensionLiveChannelsAsync([Query] object args)
            => _api.GetExtensionLiveChannelsAsync(args);
        public Task<TwitchResponse<object>> GetExtensionSecretsAsync([Query] object args)
            => _api.GetExtensionSecretsAsync(args);
        public Task<TwitchResponse<object>> PostExtensionSecretsAsync([Query] object args)
            => _api.PostExtensionSecretsAsync(args);
        public Task<TwitchResponse<object>> PostExtensionChatMessageAsync([Query] object args)
            => _api.PostExtensionChatMessageAsync(args);
        public Task<TwitchResponse<object>> GetExtensionsAsync([Query] object args)
            => _api.GetExtensionsAsync(args);
        public Task<TwitchResponse<object>> GetReleasedExtensionsAsync([Query] object args)
            => _api.GetReleasedExtensionsAsync(args);
        public Task<TwitchResponse<object>> GetExtensionBitsProductsAsync([Query] object args)
            => _api.GetExtensionBitsProductsAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionBitsProductsAsync([Query] object args)
            => _api.ModifyExtensionBitsProductsAsync(args);

        public Task<TwitchResponse<object>> PostEventSubSubcriptionAsync([Query] object args)
            => _api.PostEventSubSubcriptionAsync(args);
        public Task<TwitchResponse<object>> DeleteEventSubSubcrptionAsync([Query] object args)
            => _api.DeleteEventSubSubcrptionAsync(args);
        public Task<TwitchResponse<object>> GetEventSubSubcriptionAsync([Query] object args)
            => _api.GetEventSubSubcriptionAsync(args);

        public Task<TwitchResponse<object>> GetTopGamesAsync([Query] object args)
            => _api.GetTopGamesAsync(args);
        public Task<TwitchResponse<object>> GetGamesAsync([Query] object args)
            => _api.GetGamesAsync(args);

        public Task<TwitchResponse<object>> GetGoalsAsync([Query] object args)
            => _api.GetGoalsAsync(args);

        public Task<TwitchResponse<object>> GetHypetrainEventsAsync([Query] object args)
            => _api.GetHypetrainEventsAsync(args);

        public Task<TwitchResponse<object>> GetModerationStatusAsync([Query] object args)
            => _api.GetModerationStatusAsync(args);
        public Task<TwitchResponse<object>> GetAutomodMessagesAsync([Query] object args)
            => _api.GetAutomodMessagesAsync(args);
        public Task<TwitchResponse<object>> GetAutomodSettingsAsync([Query] object args)
            => _api.GetAutomodSettingsAsync(args);
        public Task<TwitchResponse<object>> ModifyAutomodSettingsAsync([Query] object args)
            => _api.ModifyAutomodSettingsAsync(args);
        public Task<TwitchResponse<object>> GetBannedUsersAsync([Query] object args)
            => _api.GetBannedUsersAsync(args);
        public Task<TwitchResponse<object>> PostBanAsync([Query] object args)
            => _api.PostBanAsync(args);
        public Task<TwitchResponse<object>> DeleteBanAsync([Query] object args)
            => _api.DeleteBanAsync(args);
        public Task<TwitchResponse<object>> GetBlockedTermsAsync([Query] object args)
            => _api.GetBlockedTermsAsync(args);
        public Task<TwitchResponse<object>> PostBlockedTermAsync([Query] object args)
            => _api.PostBlockedTermAsync(args);
        public Task<TwitchResponse<object>> DeleteBlockedTermAsync([Query] object args)
            => _api.DeleteBlockedTermAsync(args);
        public Task<TwitchResponse<object>> DeleteChatMessagesAsync([Query] object args)
            => _api.DeleteChatMessagesAsync(args);
        public Task<TwitchResponse<object>> GetModeratorsAsync([Query] object args)
            => _api.GetModeratorsAsync(args);
        public Task<TwitchResponse<object>> PostModeratorAsync([Query] object args)
            => _api.PostModeratorAsync(args);
        public Task<TwitchResponse<object>> DeleteModeratorAsync([Query] object args)
            => _api.DeleteModeratorAsync(args);
        public Task<TwitchResponse<object>> GetVipsAsync([Query] object args)
            => _api.GetVipsAsync(args);
        public Task<TwitchResponse<object>> PostVipAsync([Query] object args)
            => _api.PostVipAsync(args);
        public Task<TwitchResponse<object>> DeleteVipAsync([Query] object args)
            => _api.DeleteVipAsync(args);
        public Task<TwitchResponse<object>> ModifyShieldModeAsync([Query] object args)
            => _api.ModifyShieldModeAsync(args);
        public Task<TwitchResponse<object>> GetShieldModeAsync([Query] object args)
            => _api.GetShieldModeAsync(args);

        public Task<TwitchResponse<object>> GetPollAsync([Query] object args)
            => _api.GetPollAsync(args);
        public Task<TwitchResponse<object>> PostPollAsync([Query] object args)
            => _api.PostPollAsync(args);
        public Task<TwitchResponse<object>> EndPollAsync([Query] object args)
            => _api.EndPollAsync(args);

        public Task<TwitchResponse<object>> GetPredictionAsync([Query] object args)
            => _api.GetPredictionAsync(args);
        public Task<TwitchResponse<object>> PostPredictionAsync([Query] object args)
            => _api.PostPredictionAsync(args);
        public Task<TwitchResponse<object>> EndPredictionaAsync([Query] object args)
            => _api.EndPredictionaAsync(args);

        public Task<TwitchResponse<object>> PostRaidAsync([Query] object args)
            => _api.PostRaidAsync(args);
        public Task<TwitchResponse<object>> DeleteRaidAsync([Query] object args)
            => _api.DeleteRaidAsync(args);

        public Task<TwitchResponse<object>> GetScheduleAsync([Query] object args)
            => _api.GetScheduleAsync(args);
        public Task<TwitchResponse<object>> GetCalendarAsync([Query] object args)
            => _api.GetCalendarAsync(args);

        public Task<TwitchResponse<object>> ModifyScheduleAsync([Query] object args)
            => _api.ModifyScheduleAsync(args);
        public Task<TwitchResponse<object>> PostScheduleSegmentAsync([Query] object args)
            => _api.PostScheduleSegmentAsync(args);
        public Task<TwitchResponse<object>> ModifyScheduleSegmentAsync([Query] object args)
            => _api.ModifyScheduleSegmentAsync(args);
        public Task<TwitchResponse<object>> DeleteScheduleSegmentAsync([Query] object args)
            => _api.DeleteScheduleSegmentAsync(args);

        public Task<TwitchResponse<object>> GetCategoriesAsync([Query] object args)
            => _api.GetCategoriesAsync(args);
        public Task<TwitchResponse<object>> GetChannelsAsync([Query] object args)
            => _api.GetChannelsAsync(args);

        public Task<TwitchResponse<object>> GetCurrentTrackAsync([Query] object args)
            => _api.GetCurrentTrackAsync(args);
        public Task<TwitchResponse<object>> GetCurrentPlaylistAsync([Query] object args)
            => _api.GetCurrentPlaylistAsync(args);
        public Task<TwitchResponse<object>> GetPlaylistsAsync([Query] object args)
            => _api.GetPlaylistsAsync(args);

        public Task<TwitchResponse<object>> GetStreamKeyAsync([Query] object args)
            => _api.GetStreamKeyAsync(args);
        public Task<TwitchResponse<object>> GetStreamsAsync([Query] object args)
            => _api.GetStreamsAsync(args);
        public Task<TwitchResponse<object>> GetFollowedStreamsAsync([Query] object args)
            => _api.GetFollowedStreamsAsync(args);
        public Task<TwitchResponse<object>> PostStreamMarkerAsync([Query] object args)
            => _api.PostStreamMarkerAsync(args);
        public Task<TwitchResponse<object>> GetStreamMarkersAsync([Query] object args)
            => _api.GetStreamMarkersAsync(args);

        public Task<TwitchResponse<object>> GetSubscriptionsAsync([Query] object args)
            => _api.GetSubscriptionsAsync(args);
        public Task<TwitchResponse<object>> GetSubscriberAsync([Query] object args)
            => _api.GetSubscriberAsync(args);

        public Task<TwitchResponse<object>> GetTagsAsync([Query] object args)
            => _api.GetTagsAsync(args);

        public Task<TwitchResponse<object>> GetTagsAsync([Query("broadcaster_id")] string id)
            => _api.GetTagsAsync(id);
        public Task<TwitchResponse<object>> ModifyTagsAsync([Query] object args)
            => _api.ModifyTagsAsync(args);

        public Task<TwitchResponse<object>> GetTeamsAsync([Query("broadcaster_id")] string id)
            => _api.GetTeamsAsync(id);
        public Task<TwitchResponse<object>> GetTeamsAsync([Query] object args)
            => _api.GetTeamsAsync(args);

        public Task<TwitchResponse<User>> GetUsersAsync([Query] GetUsersParams args)
            => _api.GetUsersAsync(args);
        public Task<TwitchResponse<object>> ModifyUserAsync([Query] object args)
            => _api.ModifyUserAsync(args);
        public Task<TwitchResponse<object>> GetFollowsAsync([Query] object args)
            => _api.GetFollowsAsync(args);
        public Task<TwitchResponse<object>> GetBlocksAsync([Query] object args)
            => _api.GetBlocksAsync(args);
        public Task<TwitchResponse<object>> PostBlockAsync([Query] object args)
            => _api.PostBlockAsync(args);
        public Task<TwitchResponse<object>> DeleteBlockAsync([Query] object args)
            => _api.DeleteBlockAsync(args);

        public Task<TwitchResponse<object>> GetUserExtensionsAsync([Query] object args)
            => _api.GetUserExtensionsAsync(args);
        public Task<TwitchResponse<object>> GetActiveExtensionsAsync([Query] object args)
            => _api.GetActiveExtensionsAsync(args);
        public Task<TwitchResponse<object>> ModifyExtensionsAsync([Query] object args)
            => _api.ModifyExtensionsAsync(args);

        public Task<TwitchResponse<object>> GetVideosAsync([Query] object args)
            => _api.GetVideosAsync(args);
        public Task<IEnumerable<string>> DeleteVideoAsync([Query] string id)
            => _api.DeleteVideoAsync(id);

        public Task PostWhisperAsync([Query("from_user_id")] string fromUserId, [Query("to_user_id")] string toUserId, [Body] string message)
            => _api.PostWhisperAsync(fromUserId, toUserId, message);
    }
}
