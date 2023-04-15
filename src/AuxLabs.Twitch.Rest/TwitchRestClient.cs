using AuxLabs.Twitch.Rest.Api;
using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient : IDisposable
    {
        private readonly bool _downloadMy;
        private bool _disposed = false;

        internal TwitchRestApiClient API { get; }

        public RestSelfUser MyUser { get; private set; }
        public RestChannel MyChannel { get; private set; }

        public AppIdentity Identity => API.Identity;

        public TwitchRestClient(TwitchRestConfig config = null)
            : this(TwitchConstants.RestApiUrl, config) { }
        public TwitchRestClient(string url, TwitchRestConfig config = null)
        {
            config ??= new TwitchRestConfig();
            _downloadMy = config.DownloadMyInformation;

            API = new TwitchRestApiClient(url, config);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    API.Dispose();
                    MyUser = null; 
                    MyChannel = null;
                }

                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        // -- Partials --
        // ChannelPoints
        // Moderation
        // Schedules
        // Broadcasts
        // Users

        #region Identity

        private void IsUserAuthorized(out UserIdentity identity)
        {
            if (!(Identity is UserIdentity user))
                throw new TwitchException($"This method cannot be used when authenticated with an App Identity.");
            identity = user;
        }

        /// <inheritdoc cref="TwitchIdentityApiClient.ValidateAsync()" />
        public Task<AppIdentity> ValidateAsync() => API.ValidateAsync();

        /// <inheritdoc cref="TwitchIdentityApiClient.ValidateAsync(string)" />
        public async Task<AccessTokenInfo> ValidateAsync(string token, string refreshToken = null)
        {
            var identity = await API.ValidateAsync(token, refreshToken);
            if (_downloadMy)
            {
                MyUser = await GetMyUserAsync();
                MyChannel = await GetMyChannelAsync();
            }
            return identity;
        }

        #endregion
        #region Ads

        /// <summary>
        ///     Starts a commercial on the currently authorized user's channel.
        /// </summary>
        /// <param name="length">
        ///     The length of the commercial to run, in seconds.
        /// </param>
        /// <inheritdoc cref="TwitchRestApiClient.PostCommercialAsync(PostCommercialBody, System.Threading.CancellationToken?)" />
        public async Task<Commercial> StartCommercialAsync(int length, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var authorized);
            var response = await API.PostCommercialAsync(new PostCommercialBody
            {
                BroadcasterId = authorized.UserId,
                Length = length
            }, cancelToken);
            return response.Data.SingleOrDefault();
        }

        #endregion
        #region Bits

        public async Task<IReadOnlyCollection<Cheermote>> GetCheermotesAsync(string broadcasterId = null)
        {
            var response = await API.GetCheermotesAsync(broadcasterId);
            return response.Data;
        }

        public async Task<IReadOnlyCollection<RestExtensionTransaction>> GetExtensionTransactionsAsync(string extensionId, int count = 20)
        {
            var response = await API.GetExtensionTransactionsAsync(new GetExtensionTransactionsArgs
            {
                ExtensionId = extensionId,
                First = count
            });
            return response.Data.Select(x => RestExtensionTransaction.Create(this, x)).ToImmutableArray();
        }
        public async Task<IReadOnlyCollection<RestExtensionTransaction>> GetExtensionTransactionsAsync(string extensionId, int count = 20, params string[] transactionIds)
        {
            var response = await API.GetExtensionTransactionsAsync(new GetExtensionTransactionsArgs
            {
                ExtensionId = extensionId,
                TransactionIds = transactionIds,
                First = count
            });
            return response.Data.Select(x => RestExtensionTransaction.Create(this, x)).ToImmutableArray();
        }

        #endregion
        #region Charity

        // GetCharityCampaigns
        // GetCharityDonations

        #endregion
        #region Entitlements

        // GetDropStatus
        // ModifyDropStatus

        #endregion
        #region EventSub

        public async Task<IReadOnlyCollection<RestEventSubscription>> GetEventSubscriptionsAsync(string userId = null, EventSubStatus? status = null, EventSubType? type = null)
        {
            var response = await API.GetEventSubscriptionsAsync(new GetEventSubscriptionsArgs
            {
                UserId = userId,
                Status = status,
                Type = type
            });
            return response.Data.Select(x => RestEventSubscription.Create(this, x)).ToImmutableArray();
        }

        public Task<RestEventSubscription> CreateEventSubscriptionAsync<TCondition>(Action<PostEventSubscriptionBody<TCondition>> func)
            where TCondition : IEventCondition
        {
            var args = new PostEventSubscriptionBody<TCondition>();
            func(args);

            return CreateEventSubscriptionAsync(args);
        }
        public async Task<RestEventSubscription> CreateEventSubscriptionAsync<TCondition>(PostEventSubscriptionBody<TCondition> args)
            where TCondition : IEventCondition
        {
            var response = await API.PostEventSubscriptionAsync(args);
            return RestEventSubscription.Create(this, response.Data.Single());
        }

        public Task DeleteEventSubscriptionAsync(string subscriptionId)
            => API.DeleteEventSubscriptionAsync(subscriptionId);

        #endregion
        #region Games

        // GetTopGames
        // GetGames

        #endregion
        #region Goals

        // GetGoals

        #endregion
        #region HypeTrains

        // GetHypeTrainEvents

        #endregion
        #region Polls

        // GetPolls
        // CreatePoll
        // ModifyPoll

        #endregion
        #region Predictions

        // GetPredictions
        // CreatePrediction
        // ModifyPrediction

        #endregion
        #region Raids

        // StartRaid
        // StopRaid

        #endregion
        #region Search

        // GetCategories
        // GetChannels

        #endregion
        #region Soundtrack

        // GetCurrentTrack
        // GetPlaylistTracks
        // GetPlaylists

        #endregion
        #region Subscriptions

        // GetSubscriptions
        // GetSubscribers

        #endregion
        #region Teams

        // GetTeams
        // GetTeam

        #endregion
        #region Videos

        // GetVideos
        // DeleteVideo

        #endregion
        #region Whispers

        // SendWhisper

        #endregion
    }
}
