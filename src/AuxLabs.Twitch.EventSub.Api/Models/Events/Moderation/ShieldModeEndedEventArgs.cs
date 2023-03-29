using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class ShieldModeEndedEventArgs : ShieldModeEventArgs
    {
        /// <summary> The UTC timestamp of when the moderator deactivated Shield Mode. </summary>
        [JsonInclude, JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; internal set; }
    }
}
