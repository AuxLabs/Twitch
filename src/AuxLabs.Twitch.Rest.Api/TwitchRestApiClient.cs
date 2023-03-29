using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest.Api
{
    public class TwitchRestApiClient : ITwitchApi, IDisposable
    {
        private readonly TwitchIdentityApiClient _identity;
        private readonly ITwitchApi _api;
        private bool _disposed = false;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public string ClientId { get => _api.ClientId; set => _api.ClientId = value; }
        public AppIdentity Identity => _identity.Identity;

        public TwitchRestApiClient(TwitchRestApiConfig config = null)
            : this(TwitchConstants.RestApiUrl, config) { }
        public TwitchRestApiClient(string url, TwitchRestApiConfig config = null)
        {
            config ??= new TwitchRestApiConfig();
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };

            _api = RestClient.For<ITwitchApi>(new TwitchRequester(httpClient, new DefaultRateLimiter(), TwitchJsonSerializerOptions.Default));
            _identity = new TwitchIdentityApiClient(config.ClientId, config.ClientSecret);

            _api.ClientId = config.ClientId;
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _api.Dispose();
                    _identity.Dispose();
                }
                
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        private void CheckPermissions(IScopedRequest request)
        {
            if (!(Identity is UserIdentity user))
                throw new TwitchException("This request cannot be made using app authorization.");

            if (request is IAgentRequest agent)
                agent.Validate(user.Scopes, user.UserId);
            else
                request.Validate(user.Scopes);
        }

        #region Identity

        /// <inheritdoc cref="TwitchIdentityApiClient.ValidateAsync()" />
        public async Task<AppIdentity> ValidateAsync(CancellationToken? cancelToken = null)
        {
            await _identity.ValidateAsync(cancelToken);
            Authorization = new AuthenticationHeaderValue(Identity.TokenType.GetStringValue(), Identity.AccessToken);
            return Identity;
        }

        /// <inheritdoc cref="TwitchIdentityApiClient.ValidateAsync(string)" />
        public async Task<AccessTokenInfo> ValidateAsync(string token, string refreshToken = null, CancellationToken? cancelToken = null)
        {
            var tokenInfo = await _identity.ValidateAsync(token, refreshToken, cancelToken);
            Authorization = new AuthenticationHeaderValue(Identity.TokenType.GetStringValue(), Identity.AccessToken);
            ClientId = tokenInfo.ClientId;
            return tokenInfo;
        }
        
        /// <summary> Revoke the currently authorized user's token. </summary>
        public Task RevokeTokenAsync(CancellationToken? cancelToken = null)
        {
            return _identity.RevokeTokenAsync(new PostRevokeTokenArgs
            {
                ClientId = ClientId,
                Token = Authorization.Parameter
            }, cancelToken);
        }

        /// <summary> Refresh the token for the authorized user. </summary>
        public async Task<AppIdentity> RefreshTokenAsync(CancellationToken? cancelToken = null)
        {
            if (Identity is UserIdentity)      // Identity is a user, can be refreshed
            {
                return await _identity.PostRefreshTokenAsync(new PostRefreshTokenArgs
                {
                    ClientId = ClientId,
                    ClientSecret = _identity.ClientSecret,
                    RefreshToken = _identity.RefreshToken
                }, cancelToken);
            } else                             // Identity is an app, must create new
            {
                return await _identity.PostAccessTokenAsync(new PostAppAccessTokenArgs
                {
                    ClientId = ClientId,
                    ClientSecret = _identity.ClientSecret
                }, cancelToken);
            }
        }

        #endregion
        #region Ads

        /// <inheritdoc/>
        public Task<TwitchResponse<Commercial>> PostCommercialAsync(PostCommercialBody args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostCommercialAsync(args, cancelToken);
        }

        #endregion
        #region Analytics

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetExtensionAnalyticsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<GameAnalytic>> GetGameAnalyticsAsync(GetGameAnalyticsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetGameAnalyticsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BitsUser>> GetBitsLeaderboardAsync(GetBitsLeaderboardArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetBitsLeaderboardAsync(args, cancelToken);
        }

        #endregion
        #region Bits

        /// <inheritdoc/>
        public Task<TwitchResponse<Cheermote>> GetCheermotesAsync(GetCheermotesArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetCheermotesAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<ExtensionTransaction>> GetExtensionTransactionsAsync(GetExtensionTransactionsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetExtensionTransactionsAsync(args, cancelToken);
        }

        #endregion
        #region Channels

        /// <inheritdoc/>
        public Task<TwitchResponse<Channel>> GetChannelsAsync(GetChannelsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetChannelsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task PatchChannelAsync(PatchChannelArgs args, PatchChannelBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PatchChannelAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync(GetChannelEditorsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetChannelEditorsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<FollowedChannel>> GetFollowedChannelsAsync(GetFollowedChannelsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetFollowedChannelsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Follower>> GetFollowersAsync(GetFollowersArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetFollowersAsync(args, cancelToken);
        }

        #endregion
        #region Channel Points

        /// <inheritdoc/>
        public Task<TwitchResponse<Reward>> PostRewardsAsync(PostRewardArgs args, PostRewardBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostRewardsAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteRewardAsync(ManageRewardArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteRewardAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Reward>> GetRewardsAsync(GetRewardArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetRewardsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Redemption>> GetRewardRedemptionAsync(GetRedemptionsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetRewardRedemptionAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Reward>> PatchRewardAsync(ManageRewardArgs args, PostRewardBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PatchRewardAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Redemption>> PatchRewardRedemptionAsync(RedemptionStatus status, ModifyRedemptionsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PatchRewardRedemptionAsync(status, args, cancelToken);
        }

        #endregion
        #region Charity

        /// <inheritdoc/>
        public Task<TwitchResponse<CharityCampaign>> GetCharityCampaignAsync(GetCharityCampaignArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetCharityCampaignAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<CharityDonation>> GetCharityDonationsAsync(GetCharityDonationsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetCharityDonationsAsync(args, cancelToken);
        }

        #endregion
        #region Chat

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<SimpleUser>> GetChattersAsync(GetChattersArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetChattersAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Emote>> GetEmotesAsync(GetEmotesArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetEmotesAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<GlobalEmote>> GetEmotesAsync(CancellationToken? cancelToken = null)
            => _api.GetEmotesAsync(cancelToken);
        /// <inheritdoc/>
        public Task<TwitchResponse<Emote>> GetEmoteSetsAsync(GetEmoteSetsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetEmoteSetsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Badge>> GetBadgesAsync(GetBadgesArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetBadgesAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Badge>> GetBadgesAsync(CancellationToken? cancelToken = null)
            => _api.GetBadgesAsync(cancelToken);
        /// <inheritdoc/>
        public Task<TwitchResponse<ChatSettings>> GetChatSettingsAsync(GetChatSettingsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetChatSettingsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ChatSettings>> PatchChatSettingsAsync(PatchChatSettingsArgs args, PatchChatSettingsBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PatchChatSettingsAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task PostChatAnnouncementAsync(PostAnnouncementArgs args, PostAnnouncementBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostChatAnnouncementAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task PostShoutoutAsync(PostShoutoutArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostShoutoutAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<SimpleChatUser>> GetUserChatColorsAsync(GetUserColorArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetUserChatColorsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task PutUserChatColorAsync(PutUserChatColorArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PutUserChatColorAsync(args, cancelToken);
        }

        #endregion
        #region Clips

        /// <inheritdoc/>
        public Task<TwitchResponse<SimpleClip>> PostClipAsync(PostClipArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostClipAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Clip>> GetClipsAsync(GetClipsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetClipsAsync(args, cancelToken);
        }

        #endregion
        #region Entitlements

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Entitlement>> GetDropsStatusAsync(GetDropStatusArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetDropsStatusAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<EntitlementDrop>> PatchDropsStatusAsync(PatchDropsStatusArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.PatchDropsStatusAsync(args, cancelToken);
        }

        #endregion
        #region EventSub

        /// <inheritdoc/>
        public Task<EventSubResponse> PostEventSubscriptionAsync<TCondition>(PostEventSubscriptionBody<TCondition> args, CancellationToken? cancelToken = null) 
            where TCondition : IEventCondition
        {
            if (args is IScopedRequest scoped)
                CheckPermissions(scoped);
            else
                args.Validate();

            return _api.PostEventSubscriptionAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteEventSubscriptionAsync(DeleteEventSubscriptionArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.DeleteEventSubscriptionAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<EventSubResponse> GetEventSubscriptionsAsync(GetEventSubscriptionsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetEventSubscriptionsAsync(args, cancelToken);
        }

        #endregion
        #region Games

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Game>> GetTopGamesAsync(GetTopGamesArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetTopGamesAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Game>> GetGamesAsync(GetGamesArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetGamesAsync(args, cancelToken);
        }

        #endregion
        #region Goals

        /// <inheritdoc/>
        public Task<TwitchResponse<Goal>> GetGoalsAsync(GetGoalsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetGoalsAsync(args, cancelToken);
        }

        #endregion
        #region HypeTrain

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<HypeTrainInfo>> GetHypetrainEventsAsync(GetHypeTrainsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetHypetrainEventsAsync(args, cancelToken);
        }

        #endregion
        #region Moderation

        /// <inheritdoc/>
        public Task<TwitchResponse<MockMessage>> PostEnforcementStatusAsync(PostEnforcementStatusArgs args, PostEnforcementStatusBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostEnforcementStatusAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task PostAutomodMessageAsync(PostAutomodMessageArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostAutomodMessageAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<AutomodSettings>> GetAutomodSettingsAsync(AutomodSettingsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetAutomodSettingsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<AutomodSettings>> PutAutomodSettingsAsync(AutomodSettingsArgs args, PutAutomodSettingsBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            //body.Validate();
            return _api.PutAutomodSettingsAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BannedUser>> GetBannedUsersAsync(GetBannedUsersArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetBannedUsersAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Ban>> PostBanAsync(PostBanArgs args, PostBanBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostBanAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteBanAsync(DeleteBanArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteBanAsync(args, cancelToken);
        }

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BlockedTerm>> GetBlockedTermsAsync(GetBlockedTermsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetBlockedTermsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<BlockedTerm>> PostBlockedTermAsync(PostBlockedTermArgs args, PostBlockedTermBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostBlockedTermAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteBlockedTermAsync(DeleteBlockedTermsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteBlockedTermAsync(args, cancelToken);
        }

        /// <inheritdoc/>
        public Task DeleteChatMessagesAsync(DeleteMessageArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteChatMessagesAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<SimpleUser>> GetModeratorsAsync(GetModeratorsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetModeratorsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task PostModeratorAsync(ManageModeratorArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostModeratorAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteModeratorAsync(ManageModeratorArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteModeratorAsync(args, cancelToken);
        }

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<SimpleUser>> GetVipsAsync(GetVipsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetVipsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task PostVipAsync(ManageVipArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostVipAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteVipAsync(ManageVipArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteVipAsync(args, cancelToken);
        }

        /// <inheritdoc/>
        public Task<TwitchResponse<ShieldMode>> PutShieldModeAsync(PutShieldModeArgs args, PutShieldModeBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            // Body doesn't need to be validated, it's just a bool for now
            return _api.PutShieldModeAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ShieldMode>> GetShieldModeAsync(GetShieldModeArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetShieldModeAsync(args, cancelToken);
        }

        #endregion
        #region Polls

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Poll>> GetPollAsync(GetPredictionsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetPollAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Poll>> PostPollAsync(PutPollBody args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostPollAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Poll>> PatchPollAsync(PatchPollBody args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PatchPollAsync(args, cancelToken);
        }

        #endregion
        #region Predictions

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Prediction>> GetPredictionAsync(GetPredictionsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetPredictionAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Prediction>> PostPredictionAsync(PostPredictionBody args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostPredictionAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Prediction>> PatchPredictionaAsync(PostPredictionBody args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PatchPredictionaAsync(args, cancelToken);
        }

        #endregion
        #region Raids

        /// <inheritdoc/>
        public Task<TwitchResponse<Raid>> PostRaidAsync(PostRaidArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PostRaidAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteRaidAsync(DeleteRaidArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteRaidAsync(args, cancelToken);
        }

        #endregion
        #region Schedules

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Schedule>> GetScheduleAsync(GetScheduleArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetScheduleAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task PatchScheduleAsync(PatchScheduleArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PatchScheduleAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Schedule>> PostSegmentAsync(PostSegmentArgs args, PostSegmentBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostSegmentAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Schedule>> PatchSegmentAsync(ManageSegmentArgs args, PatchSegmentBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PatchSegmentAsync(args, body, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteSegmentAsync(ManageSegmentArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteSegmentAsync(args, cancelToken);
        }

        #endregion
        #region Search

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Category>> GetCategoriesAsync(SearchCategoriesArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetCategoriesAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<ChannelBroadcast>> GetChannelsAsync(SearchChannelsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetChannelsAsync(args, cancelToken);
        }

        #endregion
        #region Soundtrack

        /// <inheritdoc/>
        public Task<TwitchResponse<Soundtrack>> GetCurrentTrackAsync(GetCurrentTrackArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetCurrentTrackAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Track>> GetPlaylistTracksAsync(GetPlaylistTracksArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetPlaylistTracksAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Playlist>> GetPlaylistsAsync(GetPlaylistsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetPlaylistsAsync(args, cancelToken);
        }

        #endregion
        #region Streams / Broadcasts

        /// <inheritdoc/>
        public Task<TwitchResponse<string>> GetBroadcastKeyAsync(GetBroadcastKeyArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetBroadcastKeyAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Broadcast>> GetBroadcastsAsync(GetBroadcastsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetBroadcastsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Broadcast>> GetFollowedBroadcastsAsync(GetFollowedBroadcastsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetFollowedBroadcastsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<BroadcastMarker>> PostBroadcastMarkerAsync(PostBroadcastMarkerBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(body);
            return _api.PostBroadcastMarkerAsync(body, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BroadcastMarker>> GetBroadcastMarkersAsync(GetBroadcastMarkersArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetBroadcastMarkersAsync(args, cancelToken);
        }

        #endregion
        #region Subscriptions

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Subscription>> GetSubscriptionsAsync(GetSubscriptionsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetSubscriptionsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<SimpleSubscription>> GetSubscriberAsync(GetSubscriberArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetSubscriberAsync(args, cancelToken);
        }

        #endregion
        #region Teams

        /// <inheritdoc/>
        public Task<TwitchResponse<ChannelTeam>> GetTeamsAsync(GetChannelTeamsArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetTeamsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Team>> GetTeamAsync(GetTeamArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetTeamAsync(args, cancelToken);
        }

        #endregion
        #region Users

        /// <inheritdoc/>
        public Task<TwitchResponse<User>> GetUsersAsync(GetUsersArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetUsersAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<User>> PutUserAsync(PutUserArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PutUserAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<SimpleUser>> GetBlocksAsync(GetBlocksArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetBlocksAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task PutBlockAsync(PutBlockArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.PutBlockAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task DeleteBlockAsync(DeleteBlockArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteBlockAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Extension>> GetUserExtensionsAsync(CancellationToken? cancelToken = null)
        {
            //CheckScopes(args);
            return GetUserExtensionsAsync(cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ExtensionMap>> GetActiveExtensionsAsync(GetActiveExtensionsArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.GetActiveExtensionsAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ExtensionMap>> PutExtensionsAsync(ExtensionMap args, CancellationToken? cancelToken = null)
        {
            //CheckScopes(args);
            return _api.PutExtensionsAsync(args, cancelToken);
        }

        #endregion
        #region Videos

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Video>> GetVideosAsync(GetVideosArgs args, CancellationToken? cancelToken = null)
        {
            args.Validate();
            return _api.GetVideosAsync(args, cancelToken);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<string>> DeleteVideoAsync(DeleteVideosArgs args, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            return _api.DeleteVideoAsync(args, cancelToken);
        }
        
        #endregion
        #region Whispers

        /// <inheritdoc/>
        public Task PostWhisperAsync(PostWhisperArgs args, PostWhisperBody body, CancellationToken? cancelToken = null)
        {
            CheckPermissions(args);
            body.Validate();
            return _api.PostWhisperAsync(args, body, cancelToken);
        }

        #endregion
    }
}
