using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostAnnouncementArgs : IScopedRequest
    {
        public string[] Scopes { get; } = { "moderator:manage:announcements" };

        /// <summary> The announcement to make in the broadcaster’s chat room. </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary> The color used to highlight the announcement. </summary>
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AnnouncementColor? Color { get; set; } = null;

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotEmptyOrWhitespace(Message, nameof(Message));
            Require.LengthAtMost(Message, 500, nameof(Message));
        }
    }
}
