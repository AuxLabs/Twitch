using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AppIdentity
    {
        [JsonInclude, JsonPropertyName("access_token")]
        public string AccessToken { get; internal set; }

        [JsonInclude, JsonPropertyName("expires_in")]
        public int? ExpiresInSeconds { get; internal set; }

        [JsonInclude, JsonPropertyName("token_type")]
        public TokenType TokenType { get; internal set; }
    }
}
