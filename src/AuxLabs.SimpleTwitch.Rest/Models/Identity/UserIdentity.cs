using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class UserIdentity : AppIdentity
    {
        [JsonPropertyName("login")]
        public string UserName { get; internal set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; internal set; }

        [JsonPropertyName("scopes")]
        public IReadOnlyCollection<string> Scopes { get; internal set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; internal set; }
    }
}
