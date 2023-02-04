using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostAnnouncementArgs : IScoped
    {
        [JsonIgnore]
        public string[] Scopes { get; } = new[] { "moderator:manage:announcements" };

        /// <summary> The announcement to make in the broadcaster’s chat room. </summary>
        [JsonPropertyName("id")]
        public string Message { get; set; }

        /// <summary> The color used to highlight the announcement. </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AnnouncementColor? Color { get; set; }
    }
}
