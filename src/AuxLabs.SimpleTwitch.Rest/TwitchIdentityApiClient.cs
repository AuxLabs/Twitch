﻿using RestEase;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> A clien that implements Twitch's identity api for manging access tokens. </summary>
    public class TwitchIdentityApiClient : ITwitchIdentityApi
    {
        private readonly ITwitchIdentityApi _api;
        private bool _disposed = false;

        /// <summary> Your app’s registered client ID. </summary>
        public string ClientId { get; set; }

        /// <summary> Your app’s registered client secret. </summary>
        public string ClientSecret { get; set; }

        public TwitchIdentityApiClient()
            : this(TwitchConstants.RestIdentityApiUrl) { }
        public TwitchIdentityApiClient(string url)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            _api = RestClient.For<ITwitchIdentityApi>(url);
        }
        public TwitchIdentityApiClient(string clientId, string clientSecret)
            : this(clientId, clientSecret, TwitchConstants.RestIdentityApiUrl) { }
        public TwitchIdentityApiClient(string clientId, string clientSecret, string url)
            : this(url)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
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

        /// <summary> Get information relating to a user access token </summary>
        public Task<AccessTokenInfo> GetValidationAsync(string token)
            => _api.GetValidationAsync(token);

        /// <summary> Revoke an access token that is no longer needed </summary>
        public Task PostRevokeTokenAsync(PostRevokeTokenArgs args)
            => _api.PostRevokeTokenAsync(Fill(args));
        /// <inheritdoc cref="PostRevokeTokenAsync(PostRevokeTokenArgs)" />
        public Task PostRevokeTokenAsync(Action<PostRevokeTokenArgs> action)
            => PostRevokeTokenAsync(action.InvokeReturn());

        /// <summary> Refresh an expired user access token </summary>
        public Task<UserIdentity> PostRefreshTokenAsync(PostRefreshTokenArgs args)
            => _api.PostRefreshTokenAsync((PostRefreshTokenArgs)Fill(args));
        /// <inheritdoc cref="PostRefreshTokenAsync(PostRefreshTokenArgs)" />
        public Task<UserIdentity> PostRefreshTokenAsync(Action<PostRefreshTokenArgs> action)
            => PostRefreshTokenAsync(action.InvokeReturn());

        /// <summary> Get an access token that identifies you as the specified application </summary>
        public Task<AppIdentity> PostAccessTokenAsync(PostAppAccessTokenArgs args)
            => _api.PostAccessTokenAsync(Fill(args));
        /// <inheritdoc cref="PostAccessTokenAsync(PostAppAccessTokenParamss)" />
        public Task<AppIdentity> PostAccessTokenAsync(Action<PostAppAccessTokenArgs> action)
            => PostAccessTokenAsync(action.InvokeReturn());

        /// <summary> Get an access token that identifies you as the specified user </summary>
        public Task<UserIdentity> PostAccessTokenAsync(PostUserAccessTokenArgs args)
            => _api.PostAccessTokenAsync((PostUserAccessTokenArgs)Fill(args));
        /// <inheritdoc cref="PostAccessTokenAsync(PostUserAccessTokenArgs)" />
        public Task<UserIdentity> PostAccessTokenAsync(Action<PostUserAccessTokenArgs> action)
            => PostAccessTokenAsync(action.InvokeReturn());

        private PostAppAccessTokenArgs Fill(PostAppAccessTokenArgs args)
        {
            args.ClientId = args.ClientId ??= ClientId;
            args.ClientSecret = args.ClientSecret ??= ClientSecret;
            return args;
        }
        private PostRevokeTokenArgs Fill(PostRevokeTokenArgs args)
        {
            args.ClientId = args.ClientId ??= ClientId;
            return args;
        }
    }
}
