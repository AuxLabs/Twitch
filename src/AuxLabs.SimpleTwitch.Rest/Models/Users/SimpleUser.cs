using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleUser
    {
        /// <summary> The ID of the user </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }

    }
}
