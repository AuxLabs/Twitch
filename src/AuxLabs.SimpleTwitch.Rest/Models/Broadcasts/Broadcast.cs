using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Broadcast
    {
        /// <summary> An ID that identifies the stream. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The ID of the user that’s broadcasting the stream. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; set; }

        /// <summary> The ID of the category or game being played. </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        /// <summary> The name of the category or game being played. </summary>
        [JsonPropertyName("game_name")]
        public string GameName { get; set; }

        /// <summary> The type of stream. </summary>
        [JsonPropertyName("type")]
        public BroadcastType Type { get; set; }

        /// <summary> The stream’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The tags applied to the stream. </summary>
        [JsonPropertyName("tags")]
        public IReadOnlyCollection<string> Tags { get; set; }

        /// <summary> The number of users watching the stream. </summary>
        [JsonPropertyName("viewer_count")]
        public int ViewerCount { get; set; }

        /// <summary> The UTC date and time of when the broadcast began. </summary>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        /// <summary> The ISO 639-1 two-letter language code that the stream uses. </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary> A URL to an image of a frame from the last 5 minutes of the stream. </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary> Indicates whether the stream is meant for mature audiences. </summary>
        [JsonPropertyName("is_mature")]
        public bool IsMature { get; set; }
    }
}
