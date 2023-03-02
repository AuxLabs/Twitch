using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Clip : SimpleClip
    {
        /// <summary> A URL to the clip. </summary>
        [JsonPropertyName("url")]
        public string Url { get; internal set; }

        /// <summary> A URL that you can use in an iframe to embed the clip. </summary>
        [JsonPropertyName("embed_url")]
        public string EmbedUrl { get; internal set; }

        /// <summary> An ID that identifies the broadcaster that the video was clipped from. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> An ID that identifies the user that created the clip. </summary>
        [JsonPropertyName("creator_id")]
        public string CreatorId { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("creator_name")]
        public string CreatorDisplayName { get; internal set; }

        /// <summary> An ID that identifies the video that the clip came from. </summary>
        [JsonPropertyName("video_id")]
        public string VideoId { get; internal set; }

        /// <summary> The ID of the game that was being played when the clip was created. </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; internal set; }

        /// <summary> The language that the broadcaster broadcasts in. </summary>
        [JsonPropertyName("language")]
        public CultureInfo Language { get; internal set; }

        /// <summary> The title of the clip. </summary>
        [JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The number of times the clip has been viewed. </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; internal set; }

        /// <summary> The date and time of when the clip was created. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> A URL to a thumbnail image of the clip. </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; internal set; }

        /// <summary> The length of the clip, in seconds. </summary>
        [JsonPropertyName("duration")]
        public float DurationSeconds { get; internal set; }

        /// <summary> The zero-based offset, in seconds, to where the clip starts in the video </summary>
        [JsonPropertyName("vod_offset")]
        public int OffsetSeconds { get; internal set; }
    }
}
