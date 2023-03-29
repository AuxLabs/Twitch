using RestEase;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    [Header("User-Agent", "AuxLabs (https://github.com/AuxLabs/SimpleTwitch)")]
    public interface ITwitchIdentityApi : IDisposable
    {
        [Get("validate")]
        Task<AccessTokenInfo> ValidateAsync([Header("Authorization", Format = "Bearer {0}")] string token, CancellationToken? cancelToken = null);

        [Get("revoke")]
        Task RevokeTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostRevokeTokenArgs args, CancellationToken? cancelToken = null);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<UserIdentity> PostRefreshTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostRefreshTokenArgs args, CancellationToken? cancelToken = null);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<AppIdentity> PostAccessTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostAppAccessTokenArgs args, CancellationToken? cancelToken = null);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<UserIdentity> PostAccessTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostUserAccessTokenArgs args, CancellationToken? cancelToken = null);
    }
}
