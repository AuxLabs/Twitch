using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Video
    {
        /// <summary> An ID that identifies the video. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The ID of the stream that the video originated from if the video is a <see cref="VideoType.Archive"/>. </summary>
        [JsonInclude, JsonPropertyName("stream_id")]
        public string StreamId { get; internal set; }

        /// <summary> The ID of the broadcaster that owns the video. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The video’s title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The video’s description. </summary>
        [JsonInclude, JsonPropertyName("description")]
        public string Description { get; internal set; }

        /// <summary> The date and time, in UTC, of when the video was created. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> The date and time, in UTC, of when the video was published. </summary>
        [JsonInclude, JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; internal set; }

        /// <summary> The video’s URL. </summary>
        [JsonInclude, JsonPropertyName("url")]
        public string Url { get; internal set; }

        /// <summary> A URL to a thumbnail image of the video. </summary>
        [JsonInclude, JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; internal set; }

        /// <summary> The video’s viewable state. Always set to public. </summary>
        [JsonInclude, JsonPropertyName("viewable")]
        public string Viewable { get; internal set; }

        /// <summary> The number of times that users have watched the video. </summary>
        [JsonInclude, JsonPropertyName("view_count")]
        public int ViewCount { get; internal set; }

        /// <summary> The ISO 639-1 two-letter language code that the video was broadcast in. </summary>
        [JsonInclude, JsonPropertyName("language")]
        public string Language { get; internal set; }

        /// <summary> The video’s type. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public VideoType Type { get; internal set; }

        /// <summary> The video’s length in ISO 8601 duration format. </summary>
        [JsonInclude, JsonPropertyName("duration")]
        public string Duration { get; internal set; }

        /// <summary> The segments that Twitch Audio Recognition muted. </summary>
        [JsonInclude, JsonPropertyName("muted_segments")]
        public IReadOnlyCollection<VideoOffset> MutedSegments { get; internal set; }
    }
}
