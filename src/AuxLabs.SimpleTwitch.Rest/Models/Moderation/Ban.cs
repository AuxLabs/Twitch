using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Ban
    {
        /// <summary> The broadcaster whose chat room the user was banned from chatting in. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The moderator that banned or put the user in the timeout. </summary>
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The user that was banned or put in a timeout. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The UTC date and time that the ban or timeout was placed. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary> The UTC date and time that the timeout will end. </summary>
        [JsonPropertyName("end_time")]
        public DateTime? EndsAt { get; internal set; }
    }
}
