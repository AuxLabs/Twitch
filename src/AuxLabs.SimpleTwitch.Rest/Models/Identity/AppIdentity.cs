using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AppIdentity
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; internal set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresInSeconds { get; internal set; }

        [JsonPropertyName("token_type")]
        public TokenType TokenType { get; internal set; }
    }
}
