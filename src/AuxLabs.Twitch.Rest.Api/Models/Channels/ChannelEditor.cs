using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class ChannelEditor
    {
        /// <summary> An ID that uniquely identifies a user with editor permissions. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserName { get; internal set; }

        /// <summary> The date and time when the user became one of the broadcaster’s editors. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }
    }
}
