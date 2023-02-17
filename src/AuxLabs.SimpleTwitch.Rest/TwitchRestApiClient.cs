﻿using RestEase;
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

        public Task<TwitchResponse<Commercial>> PostCommercialAsync(PostCommercialBody args)
        {
            CheckScopes(args);
            return _api.PostCommercialAsync(args);
        }
        
        #endregion
        #region Analytics

        public Task<TwitchMetaResponse<ExtensionAnalytic>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsArgs args)
        {
            CheckScopes(args);
            return _api.GetExtensionAnalyticsAsync(args);
        }
        public Task<TwitchMetaResponse<GameAnalytic>> GetGameAnalyticsAsync(GetGameAnalyticsArgs args)
        {
            CheckScopes(args);
            return _api.GetGameAnalyticsAsync(args);
        }
        public Task<TwitchMetaResponse<BitsUser>> GetBitsLeaderboardAsync(GetBitsLeaderboardArgs args)
        {
            CheckScopes(args);
            return _api.GetBitsLeaderboardAsync(args);
        }

        #endregion  
        #region Bits

        public Task<TwitchResponse<Cheermote>> GetCheermotesAsync(GetCheermotesArgs args)
        {
            args.Validate();
            return _api.GetCheermotesAsync(args);
        }
        public Task<TwitchMetaResponse<ExtensionTransaction>> GetExtensionTransactionsAsync(GetExtensionTransactionsArgs args)
        {
            args.Validate();
            return _api.GetExtensionTransactionsAsync(args);
        }

        #endregion
        #region Channels

        public Task<TwitchResponse<Channel>> GetChannelsAsync(GetChannelsArgs args)
        {
            args.Validate();
            return _api.GetChannelsAsync(args);
        }
        public Task PatchChannelAsync(PatchChannelArgs args, PatchChannelBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PatchChannelAsync(args, body);
        }
        public Task<TwitchResponse<ChannelEditor>> GetChannelEditorsAsync(GetChannelEditorsArgs args)
        {
            CheckScopes(args);
            return _api.GetChannelEditorsAsync(args);
        }

        #endregion
        #region Channel Points

        public Task<TwitchResponse<Reward>> PostRewardsAsync(PostRewardArgs args, PostRewardBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PostRewardsAsync(args, body);
        }
        public Task DeleteRewardAsync(ManageRewardArgs args)
        {
            CheckScopes(args);
            return _api.DeleteRewardAsync(args);
        }
        public Task<TwitchResponse<Reward>> GetRewardsAsync(GetRewardArgs args)
        {
            CheckScopes(args);
            return _api.GetRewardsAsync(args);
        }
        public Task<TwitchResponse<Redemption>> GetRewardRedemptionAsync(GetRedemptionsArgs args)
        {
            CheckScopes(args);
            return _api.GetRewardRedemptionAsync(args);
        }
        public Task<TwitchResponse<Reward>> PatchRewardAsync(ManageRewardArgs args, PostRewardBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PatchRewardAsync(args, body);
        }
        public Task<TwitchResponse<Redemption>> PatchRewardRedemptionAsync(RedemptionStatus status, ModifyRedemptionsArgs args)
        {
            CheckScopes(args);
            return _api.PatchRewardRedemptionAsync(status, args);
        }

        #endregion
        #region Charity

        public Task<TwitchResponse<CharityCampaign>> GetCharityCampaignAsync(string broadcasterId)
            => _api.GetCharityCampaignAsync(broadcasterId);
        public Task<TwitchMetaResponse<CharityDonation>> GetCharityDonationsAsync(GetCharityDonationsArgs args)
        {
            CheckScopes(args);
            return _api.GetCharityDonationsAsync(args);
        }

        #endregion
        #region Chat

        public Task<TwitchMetaResponse<SimpleUser>> GetChattersAsync(GetChattersArgs args)
        {
            CheckScopes(args);
            return _api.GetChattersAsync(args);
        }
        public Task<TwitchResponse<Emote>> GetEmotesAsync(string broadcasterId)
            => _api.GetEmotesAsync(broadcasterId);
        public Task<TwitchResponse<GlobalEmote>> GetEmotesAsync()
            => _api.GetEmotesAsync();
        public Task<TwitchResponse<Emote>> GetEmoteSetsAsync(GetEmoteSetsArgs args)
        {
            args.Validate();
            return _api.GetEmoteSetsAsync(args);
        }
        public Task<TwitchResponse<Badge>> GetBadgesAsync(string broadcasterId)
            => _api.GetBadgesAsync(broadcasterId);
        public Task<TwitchResponse<Badge>> GetBadgesAsync()
            => _api.GetBadgesAsync();
        public Task<TwitchResponse<ChatSettings>> GetChatSettingsAsync(string broadcasterId, string moderatorId = null)
            => _api.GetChatSettingsAsync(broadcasterId, moderatorId);
        public Task<TwitchResponse<ChatSettings>> PatchChatSettingsAsync(string broadcasterId, string moderatorId, PatchChatSettingsArgs args)
        {
            CheckScopes(args);
            return _api.PatchChatSettingsAsync(broadcasterId, moderatorId, args);
        }
        public Task PostChatAnnouncementAsync(string broadcasterId, string moderatorId, PostAnnouncementArgs args)
        {
            CheckScopes(args);
            return _api.PostChatAnnouncementAsync(broadcasterId, moderatorId, args);
        }
        public Task PostShoutoutAsync(PostShoutoutArgs args)
        {
            CheckScopes(args);
            return _api.PostShoutoutAsync(args);
        }
        public Task<TwitchResponse<SimpleChatUser>> GetUserChatColorAsync(GetUserColorArgs args)
        {
            args.Validate();
            return _api.GetUserChatColorAsync(args);
        }
        public Task PutUserChatColor(PutUserChatColorArgs args)
        {
            CheckScopes(args);
            return _api.PutUserChatColor(args);
        }

        #endregion
        #region Clips

        public Task<TwitchResponse<SimpleClip>> PostClipAsync(PostClipArgs args)
        {
            CheckScopes(args);
            return _api.PostClipAsync(args);
        }
        public Task<TwitchMetaResponse<Clip>> GetClipsAsync(GetClipsArgs args)
            => _api.GetClipsAsync(args);

        #endregion
        #region Entitlements

        public Task<TwitchResponse<EntitlementCode>> GetCodeStatusAsync(CodeStatusArgs args)
            => _api.GetCodeStatusAsync(args);
        public Task<TwitchMetaResponse<Entitlement>> GetDropsStatusAsync(GetDropStatusArgs args)
            => _api.GetDropsStatusAsync(args);
        public Task<TwitchResponse<EntitlementDrop>> PatchDropsStatusAsync(PatchDropsStatusArgs args)
            => _api.PatchDropsStatusAsync(args);
        public Task<TwitchResponse<EntitlementCode>> PostCodeStatusAsync(CodeStatusArgs args)
            => _api.PostCodeStatusAsync(args);

        #endregion
        #region Extensions

        public Task<TwitchResponse<object>> GetExtensionConfigurationAsync(object args)
            => _api.GetExtensionConfigurationAsync(args);
        public Task<TwitchResponse<object>> PutExtensionConfigurationAsync(object args)
            => _api.PutExtensionConfigurationAsync(args);
        public Task<TwitchResponse<object>> PutExtensionRequiredConfigurationAsync(object args)
            => _api.PutExtensionRequiredConfigurationAsync(args);
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
        public Task<TwitchResponse<object>> PutExtensionBitsProductsAsync(object args)
            => _api.PutExtensionBitsProductsAsync(args);

        #endregion
        #region EventSub

        public Task<EventSubResponse> PostEventSubscriptionAsync(PostEventSubscriptionArgs args)
        {
            args.Validate();
            return _api.PostEventSubscriptionAsync(args);
        }
        public Task DeleteEventSubscriptionAsync(string eventsubId)
        {
            // Validate
            return _api.DeleteEventSubscriptionAsync(eventsubId);
        }
        public Task<EventSubResponse> GetEventSubscriptionsAsync(GetEventSubscriptionsArgs args)
        {
            args.Validate();
            return _api.GetEventSubscriptionsAsync(args);
        }

        #endregion
        #region Games

        public Task<TwitchMetaResponse<Game>> GetTopGamesAsync(GetTopGamesArgs args)
        {
            args.Validate();
            return _api.GetTopGamesAsync(args);
        }
        public Task<TwitchMetaResponse<Game>> GetGamesAsync(GetGamesArgs args)
        {
            args.Validate();
            return _api.GetGamesAsync(args);
        }

        #endregion
        #region Goals

        public Task<TwitchResponse<Goal>> GetGoalsAsync(string broadcasterId)
            => _api.GetGoalsAsync(broadcasterId);
        
        #endregion
        #region HypeTrain

        public Task<TwitchMetaResponse<HypeTrainInfo>> GetHypetrainEventsAsync(GetHypeTrainsArgs args)
        {
            CheckScopes(args);
            return _api.GetHypetrainEventsAsync(args);
        }

        #endregion
        #region Moderation

        public Task<TwitchResponse<MockMessage>> PostEnforcementStatusAsync(string broadcasterId, PostEnforcementStatusArgs args)
        {
            CheckScopes(args);
            return _api.PostEnforcementStatusAsync(broadcasterId, args);
        }
        public Task PostAutomodMessageAsync(PostAutomodMessageArgs args)
        {
            CheckScopes(args);
            return _api.PostAutomodMessageAsync(args);
        }
        public Task<TwitchResponse<AutomodSettings>> GetAutomodSettingsAsync(GetAutomodSettingsArgs args)
        {
            CheckScopes(args);
            return _api.GetAutomodSettingsAsync(args);
        }
        public Task<TwitchResponse<AutomodSettings>> PutAutomodSettingsAsync(GetAutomodSettingsArgs args, PutAutomodSettingsArgs body)
        {
            CheckScopes(args);
            CheckScopes(body);
            return _api.PutAutomodSettingsAsync(args, body);
        }
        public Task<TwitchMetaResponse<BannedUser>> GetBannedUsersAsync(GetBannedUsersArgs args)
        {
            CheckScopes(args);
            return _api.GetBannedUsersAsync(args);
        }
        public Task<TwitchResponse<Ban>> PostBanAsync(PostBanArgs args, PostBanBody body)
        {
            CheckScopes(args);
            body.Validate();
            return _api.PostBanAsync(args, body);
        }

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
        public Task<TwitchResponse<object>> PutShieldModeAsync(object args)
            => _api.PutShieldModeAsync(args);
        public Task<TwitchResponse<object>> GetShieldModeAsync(object args)
            => _api.GetShieldModeAsync(args);

        #endregion
        #region Polls

        public Task<TwitchMetaResponse<Poll>> GetPollAsync(GetPredictionsArgs args)
        {
            CheckScopes(args);
            return _api.GetPollAsync(args);
        }
        public Task<TwitchResponse<Poll>> PostPollAsync(PutPollArgs args)
        {
            CheckScopes(args);
            return _api.PostPollAsync(args);
        }
        public Task<TwitchResponse<Poll>> PatchPollAsync(PatchPollArgs args)
        {
            CheckScopes(args);
            return _api.PatchPollAsync(args);
        }

        #endregion
        #region Predictions

        public Task<TwitchMetaResponse<Prediction>> GetPredictionAsync(GetPredictionsArgs args)
        {
            CheckScopes(args);
            return _api.GetPredictionAsync(args);
        }
        public Task<TwitchResponse<Prediction>> PostPredictionAsync(PostPredictionArgs args)
        {
            CheckScopes(args);
            return _api.PostPredictionAsync(args);
        }
        public Task<TwitchResponse<Prediction>> PatchPredictionaAsync(PostPredictionArgs args)
        {
            CheckScopes(args);
            return _api.PatchPredictionaAsync(args);
        }

        #endregion
        #region Raids

        public Task<TwitchResponse<Raid>> PostRaidAsync(PostRaidArgs args)
        {
            CheckScopes(args);
            return _api.PostRaidAsync(args);
        }
        public Task DeleteRaidAsync(DeleteRaidArgs args)
        {
            CheckScopes(args);
            return _api.DeleteRaidAsync(args);
        }

        #endregion
        #region Schedules

        public Task<TwitchResponse<object>> GetScheduleAsync(object args)
            => _api.GetScheduleAsync(args);
        public Task<TwitchResponse<object>> GetCalendarAsync(object args)
            => _api.GetCalendarAsync(args);

        public Task<TwitchResponse<object>> PatchScheduleAsync(object args)
            => _api.PatchScheduleAsync(args);
        public Task<TwitchResponse<object>> PostScheduleSegmentAsync(object args)
            => _api.PostScheduleSegmentAsync(args);
        public Task<TwitchResponse<object>> PatchScheduleSegmentAsync(object args)
            => _api.PatchScheduleSegmentAsync(args);
        public Task<TwitchResponse<object>> DeleteScheduleSegmentAsync(object args)
            => _api.DeleteScheduleSegmentAsync(args);

        #endregion
        #region Search

        public Task<TwitchResponse<object>> GetCategoriesAsync(object args)
            => _api.GetCategoriesAsync(args);
        public Task<TwitchResponse<object>> GetChannelsAsync(SearchChannelsArgs args)
            => _api.GetChannelsAsync(args);

        #endregion
        #region Soundtrack

        public Task<TwitchResponse<object>> GetCurrentTrackAsync(object args)
            => _api.GetCurrentTrackAsync(args);
        public Task<TwitchResponse<object>> GetCurrentPlaylistAsync(object args)
            => _api.GetCurrentPlaylistAsync(args);
        public Task<TwitchResponse<object>> GetPlaylistsAsync(object args)
            => _api.GetPlaylistsAsync(args);

        #endregion
        #region Streams

        public Task<TwitchResponse<string>> GetStreamKeyAsync(GetStreamKeyArgs args)
            => _api.GetStreamKeyAsync(args);
        public Task<TwitchResponse<object>> GetStreamsAsync(object args)
            => _api.GetStreamsAsync(args);
        public Task<TwitchResponse<object>> GetFollowedStreamsAsync(object args)
            => _api.GetFollowedStreamsAsync(args);
        public Task<TwitchResponse<object>> PostStreamMarkerAsync(object args)
            => _api.PostStreamMarkerAsync(args);
        public Task<TwitchResponse<object>> GetStreamMarkersAsync(object args)
            => _api.GetStreamMarkersAsync(args);

        #endregion
        #region Subscriptions

        public Task<TwitchMetaResponse<Subscription>> GetSubscriptionsAsync(GetSubscriptionsArgs args)
        {
            CheckScopes(args);
            return _api.GetSubscriptionsAsync(args);
        }
        public Task<TwitchResponse<SimpleSubscription>> GetSubscriberAsync(GetSubscriberArgs args)
        {
            CheckScopes(args);
            return _api.GetSubscriberAsync(args);
        }

        #endregion
        #region Teams

        public Task<TwitchResponse<ChannelTeam>> GetTeamsAsync(string broadcasterId)
        {
            Require.NotNullOrWhitespace(broadcasterId, nameof(broadcasterId));
            return _api.GetTeamsAsync(broadcasterId);
        }
        public Task<TwitchResponse<Team>> GetTeamAsync(GetTeamArgs args)
        {
            args.Validate();
            return _api.GetTeamAsync(args);
        }

        #endregion
        #region Users

        public Task<TwitchResponse<User>> GetUsersAsync(GetUsersArgs args)
        {
            args.Validate();
            return _api.GetUsersAsync(args);
        }
        public Task<TwitchResponse<User>> PutUserAsync(string description)
        {
            //CheckScopes(args);
            return _api.PutUserAsync(description);
        }
        public Task<TwitchMetaResponse<Follower>> GetFollowsAsync(GetFollowsArgs args)
        {
            args.Validate();
            return _api.GetFollowsAsync(args);
        }
        public Task<TwitchMetaResponse<SimpleUser>> GetBlocksAsync(GetBlocksArgs args)
        {
            CheckScopes(args);
            return _api.GetBlocksAsync(args);
        }
        public Task PutBlockAsync(PutBlockArgs args)
        {
            CheckScopes(args);
            return _api.PutBlockAsync(args);
        }
        public Task DeleteBlockAsync(string targetUserId)
        {
            //CheckScopes(args);
            return _api.DeleteBlockAsync(targetUserId);
        }
        public Task<TwitchResponse<Extension>> GetUserExtensionsAsync()
        {
            //CheckScopes(args);
            return GetUserExtensionsAsync();
        }
        public Task<TwitchResponse<ExtensionMap>> GetActiveExtensionsAsync(string userId)
            => _api.GetActiveExtensionsAsync(userId);
        public Task<TwitchResponse<ExtensionMap>> PutExtensionsAsync(ExtensionMap args)
        {
            //CheckScopes(args);
            return _api.PutExtensionsAsync(args);
        }

        #endregion
        #region Videos

        public Task<TwitchMetaResponse<Video>> GetVideosAsync(GetVideosArgs args)
        {
            args.Validate();
            return _api.GetVideosAsync(args);
        }
        public Task<TwitchResponse<string>> DeleteVideoAsync(DeleteVideosArgs args)
        {
            CheckScopes(args);
            return _api.DeleteVideoAsync(args);
        }
        
        #endregion
        #region Whispers

        public Task PostWhisperAsync(string fromUserId, string toUserId, string message)
            => _api.PostWhisperAsync(fromUserId, toUserId, message);

        #endregion
    }
}
