using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Video
    {
        /// <summary> An ID that identifies the video. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The ID of the stream that the video originated from if the video is a <see cref="VideoType.Archive"/>. </summary>
        [JsonPropertyName("stream_id")]
        public string StreamId { get; set; }

        /// <summary> The ID of the broadcaster that owns the video. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; set; }

        /// <summary> The video’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The video’s description. </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary> The date and time, in UTC, of when the video was created. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> The date and time, in UTC, of when the video was published. </summary>
        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }

        /// <summary> The video’s URL. </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary> A URL to a thumbnail image of the video. </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary> The video’s viewable state. Always set to public. </summary>
        [JsonPropertyName("viewable")]
        public string Viewable { get; set; }

        /// <summary> The number of times that users have watched the video. </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        /// <summary> The ISO 639-1 two-letter language code that the video was broadcast in. </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary> The video’s type. </summary>
        [JsonPropertyName("type")]
        public VideoType Type { get; set; }

        /// <summary> The video’s length in ISO 8601 duration format. </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary> The segments that Twitch Audio Recognition muted. </summary>
        [JsonPropertyName("muted_segments")]
        public IReadOnlyCollection<VideoOffset> MutedSegments { get; set; }
    }
}
