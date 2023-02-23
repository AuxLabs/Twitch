using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ShieldMode
    {
        /// <summary> Determines whether Shield Mode is active. </summary>
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        /// <summary> An ID that identifies the moderator that last activated Shield Mode. </summary>
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; set; }

        /// <summary> The moderator’s login name. </summary>
        [JsonPropertyName("moderator_login")]
        public string ModeratorName { get; set; }

        /// <summary> The moderator’s display name. </summary>
        [JsonPropertyName("moderator_name")]
        public string ModeratorDisplayName { get; set; }

        /// <summary> The UTC timestamp of when Shield Mode was last activated. </summary>
        [JsonPropertyName("last_activated_at")]
        public DateTime LastActivatedAt { get; set; }
    }
}
