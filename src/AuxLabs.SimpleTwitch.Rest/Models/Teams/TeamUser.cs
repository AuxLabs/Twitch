using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TeamUser : IUser
    {
        /// <summary> The ID of the user </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string Id { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string Name { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string DisplayName { get; internal set; }
    }
}
