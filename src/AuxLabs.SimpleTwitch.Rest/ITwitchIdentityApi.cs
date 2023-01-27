using RestEase;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Header("User-Agent", "Auxlabs (https://github.com/AuxLabs/SimpleTwitch)")]
    public interface ITwitchIdentityApi : IDisposable
    {
        [Get("validate")]
        Task<AccessTokenInfo> GetValidationAsync([Header("Authorization", Format = "Bearer {0}")] string token);

        [Get("revoke")]
        Task PostRevokeTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostRevokeTokenParams args);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<UserIdentity> PostRefreshTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostRefreshTokenParams args);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<AppIdentity> PostAccessTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostAppAccessTokenParams args);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<UserIdentity> PostAccessTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostUserAccessTokenParams args);
    }
}
