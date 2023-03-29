using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class ShoutoutCreatedEventArgs : ShoutoutReceivedEventArgs
    {
        /// <summary> An ID that identifies the moderator that sent the Shoutout. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The moderator’s login name. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_login")]
        public string ModeratorName { get; internal set; }

        /// <summary> The moderator’s display name. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_name")]
        public string ModeratorDisplayName { get; internal set; }

        /// <summary> The UTC timestamp of when the broadcaster may send a Shoutout to a different broadcaster. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_name")]
        public DateTime CooldownEndsAt { get; internal set; }

        /// <summary> The UTC timestamp of when the broadcaster may send another Shoutout to BroadcasterId </summary>
        [JsonInclude, JsonPropertyName("moderator_user_name")]
        public DateTime TargetCooldownEndsAt { get; internal set; }
    }
}
