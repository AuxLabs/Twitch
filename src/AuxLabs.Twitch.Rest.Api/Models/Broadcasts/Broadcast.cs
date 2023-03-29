using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Broadcast
    {
        /// <summary> An ID that identifies the stream. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The ID of the user that’s broadcasting the stream. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The ID of the category or game being played. </summary>
        [JsonInclude, JsonPropertyName("game_id")]
        public string GameId { get; internal set; }

        /// <summary> The name of the category or game being played. </summary>
        [JsonInclude, JsonPropertyName("game_name")]
        public string GameName { get; internal set; }

        /// <summary> The type of stream. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public BroadcastType Type { get; internal set; }

        /// <summary> The stream’s title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The tags applied to the stream. </summary>
        [JsonInclude, JsonPropertyName("tags")]
        public IReadOnlyCollection<string> Tags { get; internal set; }

        /// <summary> The number of users watching the stream. </summary>
        [JsonInclude, JsonPropertyName("viewer_count")]
        public int ViewerCount { get; internal set; }

        /// <summary> The UTC date and time of when the broadcast began. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }

        /// <summary> The broadcaster's preferred language. </summary>
        [JsonInclude, JsonPropertyName("language")]
        public CultureInfo Culture { get; internal set; }

        /// <summary> A URL to an image of a frame from the last 5 minutes of the stream. </summary>
        [JsonInclude, JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; internal set; }

        /// <summary> Indicates whether the stream is meant for mature audiences. </summary>
        [JsonInclude, JsonPropertyName("is_mature")]
        public bool IsMature { get; internal set; }
    }
}
