using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    /// <summary> A client that implements Twitch's identity api for manging access tokens. </summary>
    public class TwitchIdentityApiClient : ITwitchIdentityApi
    {
        private readonly ITwitchIdentityApi _api;
        private bool _disposed = false;

        /// <summary> Information about the currently authorized user. </summary>
        public AppIdentity Identity { get; private set; }

        /// <summary> Your app’s registered client ID. </summary>
        public string ClientId { get; set; }

        /// <summary> Your app’s registered client secret. </summary>
        public string ClientSecret { get; set; }

        /// <summary>  </summary>
        public string RefreshToken { get; set; }

        public TwitchIdentityApiClient()
            : this(TwitchConstants.RestIdentityApiUrl) { }
        public TwitchIdentityApiClient(string clientId, string clientSecret)
            : this(clientId, clientSecret, TwitchConstants.RestIdentityApiUrl) { }
        public TwitchIdentityApiClient(string url)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            _api = new RestClient(httpClient)
            {
                ResponseDeserializer = new JsonResponseDeserializer(),
                RequestBodySerializer = new JsonBodySerializer(),
                RequestQueryParamSerializer = new JsonQueryParamSerializer()
            }.For<ITwitchIdentityApi>();
        }
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
        public Task<AccessTokenInfo> ValidateAsync(string token, string refreshToken)
        {
            RefreshToken = refreshToken;
            return ValidateAsync(token);
        }

        /// <summary> Get information relating to a user access token </summary>
        public async Task<AccessTokenInfo> ValidateAsync(string token)
        {
            var tokenInfo = await _api.ValidateAsync(token);
            ClientId = tokenInfo.ClientId;

            if (tokenInfo.UserId == null)   // Token is an app authorization
            {
                Identity = new AppIdentity
                {
                    AccessToken = token,
                    ExpiresInSeconds = tokenInfo.ExpiresInSeconds,
                    TokenType = TokenType.Bearer
                };
            }
            else                          // Token is a user authorization
            {
                Identity = new UserIdentity
                {
                    AccessToken = token,
                    ExpiresInSeconds = tokenInfo.ExpiresInSeconds,
                    UserName = tokenInfo.UserName,
                    RefreshToken = RefreshToken,
                    Scopes = tokenInfo.Scopes,
                    UserId = tokenInfo.UserId,
                    TokenType = TokenType.Bearer
                };
            }
            return tokenInfo;
        }

        /// <summary> Revoke an access token that is no longer needed </summary>
        public Task RevokeTokenAsync(PostRevokeTokenArgs args)
            => _api.RevokeTokenAsync(Fill(args));
        /// <inheritdoc cref="PostRevokeTokenAsync(PostRevokeTokenArgs)" />
        public Task RevokeTokenAsync(Action<PostRevokeTokenArgs> action)
            => RevokeTokenAsync(action.InvokeReturn());

        /// <summary> Refresh an expired user access token </summary>
        public Task<UserIdentity> PostRefreshTokenAsync(PostRefreshTokenArgs args)
            => _api.PostRefreshTokenAsync((PostRefreshTokenArgs)Fill(args));
        /// <inheritdoc cref="PostRefreshTokenAsync(PostRefreshTokenArgs)" />
        public Task<UserIdentity> PostRefreshTokenAsync(Action<PostRefreshTokenArgs> action)
            => PostRefreshTokenAsync(action.InvokeReturn());

        /// <summary> Get an access token that identifies you as the specified application </summary>
        public Task<AppIdentity> PostAccessTokenAsync(PostAppAccessTokenArgs args)
            => _api.PostAccessTokenAsync(Fill(args));
        /// <inheritdoc cref="PostAccessTokenAsync(PostAppAccessTokenArgs)" />
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
