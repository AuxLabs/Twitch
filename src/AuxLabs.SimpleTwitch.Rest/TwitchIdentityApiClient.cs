using RestEase;
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
        public Task PostRevokeTokenAsync(PostRevokeTokenParams args)
            => _api.PostRevokeTokenAsync(Fill(args));
        /// <inheritdoc cref="PostRevokeTokenAsync(PostRevokeTokenParams)" />
        public Task PostRevokeTokenAsync(Action<PostRevokeTokenParams> action)
            => PostRevokeTokenAsync(action.InvokeReturn());

        /// <summary> Refresh an expired user access token </summary>
        public Task<UserIdentity> PostRefreshTokenAsync(PostRefreshTokenParams args)
            => _api.PostRefreshTokenAsync((PostRefreshTokenParams)Fill(args));
        /// <inheritdoc cref="PostRefreshTokenAsync(PostRefreshTokenParams)" />
        public Task<UserIdentity> PostRefreshTokenAsync(Action<PostRefreshTokenParams> action)
            => PostRefreshTokenAsync(action.InvokeReturn());

        /// <summary> Get an access token that identifies you as the specified application </summary>
        public Task<AppIdentity> PostAccessTokenAsync(PostAppAccessTokenParams args)
            => _api.PostAccessTokenAsync(Fill(args));
        /// <inheritdoc cref="PostAccessTokenAsync(PostAppAccessTokenParamss)" />
        public Task<AppIdentity> PostAccessTokenAsync(Action<PostAppAccessTokenParams> action)
            => PostAccessTokenAsync(action.InvokeReturn());

        /// <summary> Get an access token that identifies you as the specified user </summary>
        public Task<UserIdentity> PostAccessTokenAsync(PostUserAccessTokenParams args)
            => _api.PostAccessTokenAsync((PostUserAccessTokenParams)Fill(args));
        /// <inheritdoc cref="PostAccessTokenAsync(PostUserAccessTokenParams)" />
        public Task<UserIdentity> PostAccessTokenAsync(Action<PostUserAccessTokenParams> action)
            => PostAccessTokenAsync(action.InvokeReturn());

        private PostAppAccessTokenParams Fill(PostAppAccessTokenParams args)
        {
            args.ClientId = args.ClientId ??= ClientId;
            args.ClientSecret = args.ClientSecret ??= ClientSecret;
            return args;
        }
        private PostRevokeTokenParams Fill(PostRevokeTokenParams args)
        {
            args.ClientId = args.ClientId ??= ClientId;
            return args;
        }
    }
}
