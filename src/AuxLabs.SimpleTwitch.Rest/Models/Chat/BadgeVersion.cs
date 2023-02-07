﻿using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public struct BadgeVersion
    {
        /// <summary> An ID that identifies this version of the badge. The ID can be any value. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> A URL to the small version (18px x 18px) of the badge. </summary>
        [JsonPropertyName("image_url_1x")]
        public string SmallImageUrl { get; set; }

        /// <summary> A URL to the medium version (36px x 36px) of the badge. </summary>
        [JsonPropertyName("image_url_2x")]
        public string MediumImageUrl { get; set; }

        /// <summary> A URL to the large version (72px x 72px) of the badge. </summary>
        [JsonPropertyName("image_url_4x")]
        public string LargeImageUrl { get; set; }
    }
}