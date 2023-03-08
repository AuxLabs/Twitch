using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class ShieldModeEventArgs
    {
        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> An ID that identifies the moderator that updated the Shield Mode’s status. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The moderator’s login name. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_login")]
        public string ModeratorName { get; internal set; }

        /// <summary> The moderator’s display name. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_name")]
        public string ModeratorDisplayName { get; internal set; }
    }
}
