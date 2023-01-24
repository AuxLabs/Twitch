using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Identity
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; }

        [JsonPropertyName("login")]
        public string Login { get; }

        [JsonPropertyName("scopes")]
        public IEnumerable<string> Scopes { get; }

        [JsonPropertyName("user_id")]
        public string UserId { get; }

        [JsonPropertyName("expires_in")]
        public TimeSpan ExpiresIn { get; }
    }
}
