using System.Text.Json.Serialization;

namespace AuxLabs.Twitch
{
    public struct TwitchImage
    {
        /// <summary> A URL to the small version (28px x 28px) of the image. </summary>
        [JsonInclude, JsonPropertyName("url_1x")]
        public string SmallImageUrl { get; internal set; }

        /// <summary> A URL to the medium version (56px x 56px) of the image. </summary>
        [JsonInclude, JsonPropertyName("url_2x")]
        public string MediumImageUrl { get; internal set; }

        /// <summary> A URL to the large version (112px x 112px) of the image. </summary>
        [JsonInclude, JsonPropertyName("url_4x")]
        public string LargeImageUrl { get; internal set; }
    }
}
