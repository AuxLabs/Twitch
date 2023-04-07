﻿using System.Text.Json.Serialization;
using System;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class CampaignEndedEventArgs : CampaignProgressEventArgs
    {
        /// <summary> The UTC timestamp of when the broadcaster stopped the campaign. </summary>
        [JsonInclude, JsonPropertyName("stopped_at")]
        public DateTime StoppedAt { get; internal set; }
    }
}