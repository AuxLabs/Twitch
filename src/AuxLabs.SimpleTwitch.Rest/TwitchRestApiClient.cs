using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
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
            _api = RestClient.For<ITwitchApi>(new TwitchRequester(httpClient, config.RateLimiter));
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

        private void CheckScopes(IScoped request)
        {
            if (!(Identity is UserIdentity user))
                throw new TwitchException("This request cannot be made using app authorization.");
            request.Validate(user.Scopes);
        }

        #region Identity

        /// <inheritdoc cref="TwitchIdentityApiClient.ValidateAsync()" />
        public async Task<AppIdentity> ValidateAsync()
        {
            await _identity.ValidateAsync();
            Authorization = new AuthenticationHeaderValue(Identity.TokenType.GetStringValue(), Identity.AccessToken);
            return Identity;
        }

        /// <inheritdoc cref="TwitchIdentityApiClient.ValidateAsync(string)" />
        public async Task<AccessTokenInfo> ValidateAsync(string token, string refreshToken = null)
        {
            var tokenInfo = await _identity.ValidateAsync(token, refreshToken);
            Authorization = new AuthenticationHeaderValue(Identity.TokenType.GetStringValue(), Identity.AccessToken);
            ClientId = tokenInfo.ClientId;
            return tokenInfo;
        }
        
        /// <summary> Revoke the currently authorized user's token. </summary>
        public Task RevokeTokenAsync()
        {
            return _identity.RevokeTokenAsync(new PostRevokeTokenArgs
            {
                ClientId = ClientId,
                Token = Authorization.Parameter
            });
        }

        /// <summary> Refresh the token for the authorized user. </summary>
        public async Task<AppIdentity> RefreshTokenAsync()
        {
            if (Identity is UserIdentity)      // Identity is a user, can be refreshed
            {
                return await _identity.PostRefreshTokenAsync(new PostRefreshTokenArgs
                {
                    ClientId = ClientId,
                    ClientSecret = _identity.ClientSecret,
                    RefreshToken = _identity.RefreshToken
                });
            } else                             // Identity is an app, must create new
            {
                return await _identity.PostAccessTokenAsync(new PostAppAccessTokenArgs
                {
                    ClientId = ClientId,
                    ClientSecret = _identity.ClientSecret
                });
            }
        }

        #endregion
        #region Ads

        /// <inheritdoc/>
        public Task<TwitchResponse<Commercial>> PostCommercialAsync(PostCommercialBody args)
        {
            CheckScopes(args);
            return _api.PostCommercialAsync(args);
        }

        #endregion
        #region Analytics

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsArgs args)
        {
            CheckScopes(args);
            return _api.GetExtensionAnalyticsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<GameAnalytic>> GetGameAnalyticsAsync(GetGameAnalyticsArgs args)
        {
            CheckScopes(args);
            return _api.GetGameAnalyticsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BitsUser>> GetBitsLeaderboardAsync(GetBitsLeaderboardArgs args)
        {
            CheckScopes(args);
            return _api.GetBitsLeaderboardAsync(args);
        }

        #endregion
        #region Bits

        /// <inheritdoc/>
        public Task<TwitchResponse<Cheermote>> GetCheermotesAsync(GetCheermotesArgs args)
        {
            args.Validate();
            return _api.GetCheermotesAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<ExtensionTransaction>> GetExtensionTransactionsAsync(GetExtensionTransactionsArgs args)
        {
            args.Validate();
            return _api.GetExtensionTransactionsAsync(args);
        }

        #endregion
        #region Channels

        /// <inheritdoc/>
        public Task<TwitchResponse<Channel>> GetChannelsAsync(GetChannelsArgs args)
        {
            args.Validate();
            return _api.GetChannelsAsync(args);
        }
        /// <inheritdoc/>
        public Task PatchChannelAsync(PatchChannelArgs args, PatchChannelBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PatchChannelAsync(args, body);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync(GetChannelEditorsArgs args)
        {
            CheckScopes(args);
            return _api.GetChannelEditorsAsync(args);
        }

        #endregion
        #region Channel Points

        /// <inheritdoc/>
        public Task<TwitchResponse<Reward>> PostRewardsAsync(PostRewardArgs args, PostRewardBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PostRewardsAsync(args, body);
        }
        /// <inheritdoc/>
        public Task DeleteRewardAsync(ManageRewardArgs args)
        {
            CheckScopes(args);
            return _api.DeleteRewardAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Reward>> GetRewardsAsync(GetRewardArgs args)
        {
            CheckScopes(args);
            return _api.GetRewardsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Redemption>> GetRewardRedemptionAsync(GetRedemptionsArgs args)
        {
            CheckScopes(args);
            return _api.GetRewardRedemptionAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Reward>> PatchRewardAsync(ManageRewardArgs args, PostRewardBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PatchRewardAsync(args, body);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Redemption>> PatchRewardRedemptionAsync(RedemptionStatus status, ModifyRedemptionsArgs args)
        {
            CheckScopes(args);
            return _api.PatchRewardRedemptionAsync(status, args);
        }

        #endregion
        #region Charity

        /// <inheritdoc/>
        public Task<TwitchResponse<CharityCampaign>> GetCharityCampaignAsync(string broadcasterId)
            => _api.GetCharityCampaignAsync(broadcasterId);
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<CharityDonation>> GetCharityDonationsAsync(GetCharityDonationsArgs args)
        {
            CheckScopes(args);
            return _api.GetCharityDonationsAsync(args);
        }

        #endregion
        #region Chat

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<SimpleUser>> GetChattersAsync(GetChattersArgs args)
        {
            CheckScopes(args);
            return _api.GetChattersAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Emote>> GetEmotesAsync(string broadcasterId)
            => _api.GetEmotesAsync(broadcasterId);
        /// <inheritdoc/>
        public Task<TwitchResponse<GlobalEmote>> GetEmotesAsync()
            => _api.GetEmotesAsync();
        /// <inheritdoc/>
        public Task<TwitchResponse<Emote>> GetEmoteSetsAsync(GetEmoteSetsArgs args)
        {
            args.Validate();
            return _api.GetEmoteSetsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Badge>> GetBadgesAsync(string broadcasterId)
            => _api.GetBadgesAsync(broadcasterId);
        /// <inheritdoc/>
        public Task<TwitchResponse<Badge>> GetBadgesAsync()
            => _api.GetBadgesAsync();
        /// <inheritdoc/>
        public Task<TwitchResponse<ChatSettings>> GetChatSettingsAsync(GetChatSettingsArgs args)
        {
            args.Validate();
            return _api.GetChatSettingsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ChatSettings>> PatchChatSettingsAsync(PatchChatSettingsArgs args, PatchChatSettingsBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PatchChatSettingsAsync(args, body);
        }
        /// <inheritdoc/>
        public Task PostChatAnnouncementAsync(string broadcasterId, string moderatorId, PostAnnouncementArgs args)
        {
            CheckScopes(args);
            return _api.PostChatAnnouncementAsync(broadcasterId, moderatorId, args);
        }
        /// <inheritdoc/>
        public Task PostShoutoutAsync(PostShoutoutArgs args)
        {
            CheckScopes(args);
            return _api.PostShoutoutAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<SimpleChatUser>> GetUserChatColorAsync(GetUserColorArgs args)
        {
            args.Validate();
            return _api.GetUserChatColorAsync(args);
        }
        /// <inheritdoc/>
        public Task PutUserChatColor(PutUserChatColorArgs args)
        {
            CheckScopes(args);
            return _api.PutUserChatColor(args);
        }

        #endregion
        #region Clips

        /// <inheritdoc/>
        public Task<TwitchResponse<SimpleClip>> PostClipAsync(PostClipArgs args)
        {
            CheckScopes(args);
            return _api.PostClipAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Clip>> GetClipsAsync(GetClipsArgs args)
            => _api.GetClipsAsync(args);

        #endregion
        #region Entitlements

        /// <inheritdoc/>
        public Task<TwitchResponse<EntitlementCode>> GetCodeStatusAsync(CodeStatusArgs args)
            => _api.GetCodeStatusAsync(args);
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Entitlement>> GetDropsStatusAsync(GetDropStatusArgs args)
            => _api.GetDropsStatusAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<EntitlementDrop>> PatchDropsStatusAsync(PatchDropsStatusArgs args)
            => _api.PatchDropsStatusAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<EntitlementCode>> PostCodeStatusAsync(CodeStatusArgs args)
            => _api.PostCodeStatusAsync(args);

        #endregion
        #region Extensions

        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetExtensionConfigurationAsync(object args)
            => _api.GetExtensionConfigurationAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PutExtensionConfigurationAsync(object args)
            => _api.PutExtensionConfigurationAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PutExtensionRequiredConfigurationAsync(object args)
            => _api.PutExtensionRequiredConfigurationAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostExtensionPubsubMessageAsync(object args)
            => _api.PostExtensionPubsubMessageAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetExtensionLiveChannelsAsync(object args)
            => _api.GetExtensionLiveChannelsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetExtensionSecretsAsync(object args)
            => _api.GetExtensionSecretsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostExtensionSecretsAsync(object args)
            => _api.PostExtensionSecretsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostExtensionChatMessageAsync(object args)
            => _api.PostExtensionChatMessageAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetExtensionsAsync(object args)
            => _api.GetExtensionsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetReleasedExtensionsAsync(object args)
            => _api.GetReleasedExtensionsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetExtensionBitsProductsAsync(object args)
            => _api.GetExtensionBitsProductsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PutExtensionBitsProductsAsync(object args)
            => _api.PutExtensionBitsProductsAsync(args);

        #endregion
        #region EventSub

        /// <inheritdoc/>
        public Task<EventSubResponse> PostEventSubscriptionAsync(PostEventSubscriptionArgs args)
        {
            args.Validate();
            return _api.PostEventSubscriptionAsync(args);
        }
        /// <inheritdoc/>
        public Task DeleteEventSubscriptionAsync(string eventsubId)
        {
            // Validate
            return _api.DeleteEventSubscriptionAsync(eventsubId);
        }
        /// <inheritdoc/>
        public Task<EventSubResponse> GetEventSubscriptionsAsync(GetEventSubscriptionsArgs args)
        {
            args.Validate();
            return _api.GetEventSubscriptionsAsync(args);
        }

        #endregion
        #region Games

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Game>> GetTopGamesAsync(GetTopGamesArgs args)
        {
            args.Validate();
            return _api.GetTopGamesAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Game>> GetGamesAsync(GetGamesArgs args)
        {
            args.Validate();
            return _api.GetGamesAsync(args);
        }

        #endregion
        #region Goals

        /// <inheritdoc/>
        public Task<TwitchResponse<Goal>> GetGoalsAsync(GetGoalsArgs args)
        {
            CheckScopes(args);
            return _api.GetGoalsAsync(args);
        }

        #endregion
        #region HypeTrain

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<HypeTrainInfo>> GetHypetrainEventsAsync(GetHypeTrainsArgs args)
        {
            CheckScopes(args);
            return _api.GetHypetrainEventsAsync(args);
        }

        #endregion
        #region Moderation

        /// <inheritdoc/>
        public Task<TwitchResponse<MockMessage>> PostEnforcementStatusAsync(string broadcasterId, PostEnforcementStatusBody args)
        {
            CheckScopes(args);
            return _api.PostEnforcementStatusAsync(broadcasterId, args);
        }
        /// <inheritdoc/>
        public Task PostAutomodMessageAsync(PostAutomodMessageArgs args)
        {
            CheckScopes(args);
            return _api.PostAutomodMessageAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<AutomodSettings>> GetAutomodSettingsAsync(AutomodSettingsArgs args)
        {
            CheckScopes(args);
            return _api.GetAutomodSettingsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<AutomodSettings>> PutAutomodSettingsAsync(AutomodSettingsArgs args, PutAutomodSettingsBody body)
        {
            CheckScopes(args);
            //body.Validate();
            return _api.PutAutomodSettingsAsync(args, body);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BannedUser>> GetBannedUsersAsync(GetBannedUsersArgs args)
        {
            CheckScopes(args);
            return _api.GetBannedUsersAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Ban>> PostBanAsync(PostBanArgs args, PostBanBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PostBanAsync(args, body);
        }
        /// <inheritdoc/>
        public Task DeleteBanAsync(DeleteBanArgs args)
        {
            CheckScopes(args);
            return _api.DeleteBanAsync(args);
        }

        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetBlockedTermsAsync(object args)
            => _api.GetBlockedTermsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostBlockedTermAsync(object args)
            => _api.PostBlockedTermAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> DeleteBlockedTermAsync(object args)
            => _api.DeleteBlockedTermAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> DeleteChatMessagesAsync(object args)
            => _api.DeleteChatMessagesAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetModeratorsAsync(object args)
            => _api.GetModeratorsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostModeratorAsync(object args)
            => _api.PostModeratorAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> DeleteModeratorAsync(object args)
            => _api.DeleteModeratorAsync(args);

        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetVipsAsync(object args)
            => _api.GetVipsAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostVipAsync(object args)
            => _api.PostVipAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> DeleteVipAsync(object args)
            => _api.DeleteVipAsync(args);

        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PutShieldModeAsync(object args)
            => _api.PutShieldModeAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetShieldModeAsync(object args)
            => _api.GetShieldModeAsync(args);

        #endregion
        #region Polls

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Poll>> GetPollAsync(GetPredictionsArgs args)
        {
            CheckScopes(args);
            return _api.GetPollAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Poll>> PostPollAsync(PutPollArgs args)
        {
            CheckScopes(args);
            return _api.PostPollAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Poll>> PatchPollAsync(PatchPollArgs args)
        {
            CheckScopes(args);
            return _api.PatchPollAsync(args);
        }

        #endregion
        #region Predictions

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Prediction>> GetPredictionAsync(GetPredictionsArgs args)
        {
            CheckScopes(args);
            return _api.GetPredictionAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Prediction>> PostPredictionAsync(PostPredictionArgs args)
        {
            CheckScopes(args);
            return _api.PostPredictionAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Prediction>> PatchPredictionaAsync(PostPredictionArgs args)
        {
            CheckScopes(args);
            return _api.PatchPredictionaAsync(args);
        }

        #endregion
        #region Raids

        /// <inheritdoc/>
        public Task<TwitchResponse<Raid>> PostRaidAsync(PostRaidArgs args)
        {
            CheckScopes(args);
            return _api.PostRaidAsync(args);
        }
        /// <inheritdoc/>
        public Task DeleteRaidAsync(DeleteRaidArgs args)
        {
            CheckScopes(args);
            return _api.DeleteRaidAsync(args);
        }

        #endregion
        #region Schedules

        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetScheduleAsync(object args)
            => _api.GetScheduleAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> GetCalendarAsync(object args)
            => _api.GetCalendarAsync(args);

        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PatchScheduleAsync(object args)
            => _api.PatchScheduleAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PostScheduleSegmentAsync(object args)
            => _api.PostScheduleSegmentAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> PatchScheduleSegmentAsync(object args)
            => _api.PatchScheduleSegmentAsync(args);
        /// <inheritdoc/>
        public Task<TwitchResponse<object>> DeleteScheduleSegmentAsync(object args)
            => _api.DeleteScheduleSegmentAsync(args);

        #endregion
        #region Search

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Category>> GetCategoriesAsync(SearchCategoriesArgs args)
        {
            args.Validate();
            return _api.GetCategoriesAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<ChannelBroadcast>> GetChannelsAsync(SearchChannelsArgs args)
        {
            args.Validate();
            return _api.GetChannelsAsync(args);
        }

        #endregion
        #region Soundtrack

        /// <inheritdoc/>
        public Task<TwitchResponse<Soundtrack>> GetCurrentTrackAsync(GetCurrentTrackArgs args)
        {
            args.Validate();
            return _api.GetCurrentTrackAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Track>> GetPlaylistTracksAsync(GetPlaylistTracksArgs args)
        {
            args.Validate();
            return _api.GetPlaylistTracksAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Playlist>> GetPlaylistsAsync(GetPlaylistsArgs args)
        {
            args.Validate();
            return _api.GetPlaylistsAsync(args);
        }

        #endregion
        #region Streams

        /// <inheritdoc/>
        public Task<TwitchResponse<string>> GetBroadcastKeyAsync(GetBroadcastKeyArgs args)
        {
            CheckScopes(args);
            return _api.GetBroadcastKeyAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Broadcast>> GetBroadcastsAsync(GetBroadcastsArgs args)
        {
            args.Validate();
            return _api.GetBroadcastsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Broadcast>> GetFollowedBroadcastsAsync(GetFollowedBroadcastsArgs args)
        {
            CheckScopes(args);
            return _api.GetFollowedBroadcastsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<BroadcastMarker>> PostBroadcastMarkerAsync(PostBroadcastMarkerBody body)
        {
            CheckScopes(body);
            return _api.PostBroadcastMarkerAsync(body);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<BroadcastMarker>> GetBroadcastMarkersAsync(GetBroadcastMarkersArgs args)
        {
            CheckScopes(args);
            return _api.GetBroadcastMarkersAsync(args);
        }

        #endregion
        #region Subscriptions

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Subscription>> GetSubscriptionsAsync(GetSubscriptionsArgs args)
        {
            CheckScopes(args);
            return _api.GetSubscriptionsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<SimpleSubscription>> GetSubscriberAsync(GetSubscriberArgs args)
        {
            CheckScopes(args);
            return _api.GetSubscriberAsync(args);
        }

        #endregion
        #region Teams

        /// <inheritdoc/>
        public Task<TwitchResponse<ChannelTeam>> GetTeamsAsync(string broadcasterId)
        {
            Require.NotNullOrWhitespace(broadcasterId, nameof(broadcasterId));
            return _api.GetTeamsAsync(broadcasterId);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Team>> GetTeamAsync(GetTeamArgs args)
        {
            args.Validate();
            return _api.GetTeamAsync(args);
        }

        #endregion
        #region Users

        /// <inheritdoc/>
        public Task<TwitchResponse<User>> GetUsersAsync(GetUsersArgs args)
        {
            args.Validate();
            return _api.GetUsersAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<User>> PutUserAsync(string description)
        {
            //CheckScopes(args);
            return _api.PutUserAsync(description);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Follower>> GetFollowsAsync(GetFollowsArgs args)
        {
            args.Validate();
            return _api.GetFollowsAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchMetaResponse<SimpleUser>> GetBlocksAsync(GetBlocksArgs args)
        {
            CheckScopes(args);
            return _api.GetBlocksAsync(args);
        }
        /// <inheritdoc/>
        public Task PutBlockAsync(PutBlockArgs args)
        {
            CheckScopes(args);
            return _api.PutBlockAsync(args);
        }
        /// <inheritdoc/>
        public Task DeleteBlockAsync(string targetUserId)
        {
            //CheckScopes(args);
            return _api.DeleteBlockAsync(targetUserId);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<Extension>> GetUserExtensionsAsync()
        {
            //CheckScopes(args);
            return GetUserExtensionsAsync();
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<ExtensionMap>> GetActiveExtensionsAsync(string userId)
            => _api.GetActiveExtensionsAsync(userId);
        /// <inheritdoc/>
        public Task<TwitchResponse<ExtensionMap>> PutExtensionsAsync(ExtensionMap args)
        {
            //CheckScopes(args);
            return _api.PutExtensionsAsync(args);
        }

        #endregion
        #region Videos

        /// <inheritdoc/>
        public Task<TwitchMetaResponse<Video>> GetVideosAsync(GetVideosArgs args)
        {
            args.Validate();
            return _api.GetVideosAsync(args);
        }
        /// <inheritdoc/>
        public Task<TwitchResponse<string>> DeleteVideoAsync(DeleteVideosArgs args)
        {
            CheckScopes(args);
            return _api.DeleteVideoAsync(args);
        }
        
        #endregion
        #region Whispers

        /// <inheritdoc/>
        public Task PostWhisperAsync(string fromUserId, string toUserId, string message)
            => _api.PostWhisperAsync(fromUserId, toUserId, message);

        #endregion
    }
}
