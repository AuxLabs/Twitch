using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CustomRewardImage
    {
        /// <summary> The URL to a small version of the image. </summary>
        [JsonPropertyName("url_1x")]
        public string SmallUrl { get; set; }

        /// <summary> The URL to a medium version of the image. </summary>
        [JsonPropertyName("url_2x")]
        public string MediumUrl { get; set; }

        /// <summary> The URL to a large version of the image. </summary>
        [JsonPropertyName("url_4x")]
        public string LargeUrl { get; set; }
    }
}
