﻿using RestEase;
using System;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Header("User-Agent", "AuxLabs (https://github.com/AuxLabs/SimpleTwitch)")]
    public interface ITwitchIdentityApi : IDisposable
    {
        [Get("validate")]
        Task<AccessTokenInfo> ValidateAsync([Header("Authorization", Format = "Bearer {0}")] string token);

        [Get("revoke")]
        Task RevokeTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostRevokeTokenArgs args);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<UserIdentity> PostRefreshTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostRefreshTokenArgs args);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<AppIdentity> PostAccessTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostAppAccessTokenArgs args);

        [Post("token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<UserIdentity> PostAccessTokenAsync([Body(BodySerializationMethod.UrlEncoded)] PostUserAccessTokenArgs args);
    }
}
