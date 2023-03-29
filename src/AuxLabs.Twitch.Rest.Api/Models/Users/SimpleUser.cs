using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class SimpleUser : IUser
    {
        /// <summary> The ID of the user </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("login")]
        public string Name { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("display_name")]
        public string DisplayName { get; internal set; }
    }
}
