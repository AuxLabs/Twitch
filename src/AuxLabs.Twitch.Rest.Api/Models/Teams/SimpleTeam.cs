using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class SimpleTeam
    {
        /// <summary> An ID that identifies the team. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The team’s name. </summary>
        [JsonInclude, JsonPropertyName("team_name")]
        public string Name { get; internal set; }

        /// <summary> The team’s display name. </summary>
        [JsonInclude, JsonPropertyName("team_display_name")]
        public string DisplayName { get; internal set; }

        /// <summary> A URL to the team’s background image. </summary>
        [JsonInclude, JsonPropertyName("background_image_url")]
        public string BackgroundImageUrl { get; internal set; }

        /// <summary> A URL to the team’s banner. </summary>
        [JsonInclude, JsonPropertyName("banner")]
        public string BannerUrl { get; internal set; }

        /// <summary> The UTC date and time of when the team was created. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> The UTC date and time of the last time the team was updated. </summary>
        [JsonInclude, JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; internal set; }

        /// <summary> The team’s description. The description may contain formatting such as Markdown, HTML, newline (\n) characters, etc. </summary>
        [JsonInclude, JsonPropertyName("info")]
        public string Description { get; internal set; }

        /// <summary> A URL to a thumbnail image of the team’s logo. </summary>
        [JsonInclude, JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; internal set; }
    }
}
