using RestEase;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
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

            _api = RestClient.For<ITwitchIdentityApi>(new TwitchRequester(httpClient, null, TwitchJsonSerializerOptions.Default));
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

        /// <summary> Get an app identity using the provided app credentials. </summary>
        public async Task<AppIdentity> ValidateAsync(CancellationToken? cancelToken = null)
        {
            Identity = await PostAccessTokenAsync(new PostAppAccessTokenArgs
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            }, cancelToken);
            return Identity;
        }

        /// <summary> Get information relating to a user access token </summary>
        public Task<AccessTokenInfo> ValidateAsync(string token, string refreshToken, CancellationToken? cancelToken = null)
        {
            RefreshToken = refreshToken;
            return ValidateAsync(token, cancelToken);
        }

        /// <summary> Get information relating to a user access token </summary>
        public async Task<AccessTokenInfo> ValidateAsync(string token, CancellationToken? cancelToken = null)
        {
            Require.NotNullOrWhitespace(token, nameof(token));

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
        public Task RevokeTokenAsync(PostRevokeTokenArgs args, CancellationToken? cancelToken = null)
            => _api.RevokeTokenAsync(Fill(args));

        /// <summary> Refresh an expired user access token </summary>
        public Task<UserIdentity> PostRefreshTokenAsync(PostRefreshTokenArgs args, CancellationToken? cancelToken = null)
            => _api.PostRefreshTokenAsync((PostRefreshTokenArgs)Fill(args));

        /// <summary> Get an access token that identifies you as the specified application </summary>
        public Task<AppIdentity> PostAccessTokenAsync(PostAppAccessTokenArgs args, CancellationToken? cancelToken = null)
            => _api.PostAccessTokenAsync(Fill(args));

        /// <summary> Get an access token that identifies you as the specified user </summary>
        public Task<UserIdentity> PostAccessTokenAsync(PostUserAccessTokenArgs args, CancellationToken? cancelToken = null)
            => _api.PostAccessTokenAsync((PostUserAccessTokenArgs)Fill(args));

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
