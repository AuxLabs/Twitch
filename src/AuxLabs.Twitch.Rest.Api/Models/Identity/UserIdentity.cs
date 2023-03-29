using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class UserIdentity : AppIdentity
    {
        [JsonInclude, JsonPropertyName("login")]
        public string UserName { get; internal set; }

        [JsonInclude, JsonPropertyName("refresh_token")]
        public string RefreshToken { get; internal set; }

        [JsonInclude, JsonPropertyName("scopes")]
        public IReadOnlyCollection<string> Scopes { get; internal set; }

        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }
    }
}
