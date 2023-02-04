using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AppIdentity
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresInSeconds { get; set; }

        [JsonPropertyName("token_type")]
        public TokenType TokenType { get; set; }
    }
}
