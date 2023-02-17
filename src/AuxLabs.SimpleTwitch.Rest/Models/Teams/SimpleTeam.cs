using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleTeam
    {
        /// <summary> An ID that identifies the team. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The team’s name. </summary>
        [JsonPropertyName("team_name")]
        public string Name { get; set; }

        /// <summary> The team’s display name. </summary>
        [JsonPropertyName("team_display_name")]
        public string DisplayName { get; set; }

        /// <summary> A URL to the team’s background image. </summary>
        [JsonPropertyName("background_image_url")]
        public string BackgroundImageUrl { get; set; }

        /// <summary> A URL to the team’s banner. </summary>
        [JsonPropertyName("banner")]
        public string BannerUrl { get; set; }

        /// <summary> The UTC date and time of when the team was created. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> The UTC date and time of the last time the team was updated. </summary>
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary> The team’s description. The description may contain formatting such as Markdown, HTML, newline (\n) characters, etc. </summary>
        [JsonPropertyName("info")]
        public string Description { get; set; }

        /// <summary> A URL to a thumbnail image of the team’s logo. </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}
