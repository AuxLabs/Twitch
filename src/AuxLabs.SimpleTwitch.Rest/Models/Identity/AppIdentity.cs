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
        [JsonConverter(typeof(NullableEnumStringConverter<TokenType>))]
        public TokenType TokenType { get; set; }
    }
}
