using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TeamUser : IUser
    {
        /// <summary> The ID of the user </summary>
        [JsonPropertyName("user_id")]
        public string Id { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string Name { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string DisplayName { get; internal set; }
    }
}
