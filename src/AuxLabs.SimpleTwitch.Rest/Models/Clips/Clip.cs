using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Clip : SimpleClip
    {
        /// <summary> A URL to the clip. </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary> A URL that you can use in an iframe to embed the clip. </summary>
        [JsonPropertyName("embed_url")]
        public string EmbedUrl { get; set; }

        /// <summary> An ID that identifies the broadcaster that the video was clipped from. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> An ID that identifies the user that created the clip. </summary>
        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("creator_name")]
        public string CreatorDisplayName { get; set; }

        /// <summary> An ID that identifies the video that the clip came from. </summary>
        [JsonPropertyName("video_id")]
        public string VideoId { get; set; }

        /// <summary> The ID of the game that was being played when the clip was created. </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        /// <summary> The language that the broadcaster broadcasts in. </summary>
        [JsonPropertyName("language")]
        public CultureInfo Language { get; set; }

        /// <summary> The title of the clip. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The number of times the clip has been viewed. </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        /// <summary> The date and time of when the clip was created. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> A URL to a thumbnail image of the clip. </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary> The length of the clip, in seconds. </summary>
        [JsonPropertyName("duration")]
        public float DurationSeconds { get; set; }

        /// <summary> The zero-based offset, in seconds, to where the clip starts in the video </summary>
        [JsonPropertyName("vod_offset")]
        public int OffsetSeconds { get; set; }
    }
}
