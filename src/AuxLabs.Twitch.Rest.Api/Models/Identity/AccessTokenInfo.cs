using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class AccessTokenInfo
    {
        [JsonInclude, JsonPropertyName("client_id")]
        public string ClientId { get; internal set; }

        [JsonInclude, JsonPropertyName("login")]
        public string UserName { get; internal set; }

        [JsonInclude, JsonPropertyName("scopes")]
        public IReadOnlyCollection<string> Scopes { get; internal set; }

        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        [JsonInclude, JsonPropertyName("expires_in")]
        public int? ExpiresInSeconds { get; internal set; }
    }
}
