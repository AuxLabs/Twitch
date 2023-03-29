using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class CampaignStartedEventArgs : CampaignProgressEventArgs
    {
        /// <summary> The UTC timestamp of when the broadcaster started the campaign. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }
    }
}
