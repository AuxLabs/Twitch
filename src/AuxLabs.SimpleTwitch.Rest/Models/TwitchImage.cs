﻿using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public struct TwitchImage
    {
        /// <summary> A URL to the small version (28px x 28px) of the image. </summary>
        [JsonPropertyName("url_1x")]
        public string SmallImageUrl { get; set; }

        /// <summary> A URL to the medium version (56px x 56px) of the image. </summary>
        [JsonPropertyName("url_2x")]
        public string MediumImageUrl { get; set; }

        /// <summary> A URL to the large version (112px x 112px) of the image. </summary>
        [JsonPropertyName("url_4x")]
        public string LargeImageUrl { get; set; }
    }
}