using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AccessTokenInfo
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; internal set; }

        [JsonPropertyName("login")]
        public string UserName { get; internal set; }

        [JsonPropertyName("scopes")]
        public IReadOnlyCollection<string> Scopes { get; internal set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresInSeconds { get; internal set; }
    }
}
