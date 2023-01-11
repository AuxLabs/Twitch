namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Identity
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; init; }

        [JsonPropertyName("login")]
        public string Login { get; init; }

        [JsonPropertyName("scopes")]
        public IEnumerable<string> Scopes { get; init; }

        [JsonPropertyName("user_id")]
        public string UserId { get; init; }

        [JsonPropertyName("expires_in")]
        public TimeSpan ExpiresIn { get; init; }
    }
}
