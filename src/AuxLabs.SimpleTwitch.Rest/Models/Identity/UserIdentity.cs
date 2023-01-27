using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class UserIdentity : AppIdentity
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("scopes")]
        public IReadOnlyCollection<string> Scopes { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
