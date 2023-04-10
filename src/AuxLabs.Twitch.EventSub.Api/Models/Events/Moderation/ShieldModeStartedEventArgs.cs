using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class ShieldModeEnabledEventArgs : ShieldModeEventArgs
    {
        /// <summary> The UTC timestamp of when the moderator activated Shield Mode. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime EnabledAt { get; internal set; }
    }
}
