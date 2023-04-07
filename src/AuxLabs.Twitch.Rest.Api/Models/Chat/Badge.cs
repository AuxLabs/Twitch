using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Badge
    {
        /// <summary> An ID that identifies this version of the badge. The ID can be any value. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The title of the badge. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The description of the badge. </summary>
        [JsonInclude, JsonPropertyName("description")]
        public string Description { get; internal set; }

        /// <summary> The action to take when clicking on the badge. </summary>
        [JsonInclude, JsonPropertyName("click_action")]
        public string ClickAction { get; internal set; }

        /// <summary> The URL to navigate to when clicking on the badge. </summary>
        [JsonInclude, JsonPropertyName("click_url")]
        public string ClickUrl { get; internal set; }

        /// <summary> A URL to the small version (18px x 18px) of the badge. </summary>
        [JsonInclude, JsonPropertyName("image_url_1x")]
        public string SmallImageUrl { get; internal set; }

        /// <summary> A URL to the medium version (36px x 36px) of the badge. </summary>
        [JsonInclude, JsonPropertyName("image_url_2x")]
        public string MediumImageUrl { get; internal set; }

        /// <summary> A URL to the large version (72px x 72px) of the badge. </summary>
        [JsonInclude, JsonPropertyName("image_url_4x")]
        public string LargeImageUrl { get; internal set; }
    }
}
