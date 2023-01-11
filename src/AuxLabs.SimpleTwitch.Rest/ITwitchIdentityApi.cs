﻿using AuxLabs.SimpleTwitch.Rest.Models;
using RestEase;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    [Header("User-Agent", "Auxlabs (https://github.com/AuxLabs/SimpleTwitch)")]
    public interface ITwitchIdentityApi : IDisposable
    {
        Identity Identity { get; }

        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("oauth2/validate")]
        Task<Identity> ValidateAsync();
    }
}