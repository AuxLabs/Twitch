﻿using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class ShieldModeStartedEventArgs : ShieldModeEventArgs
    {
        /// <summary> The UTC timestamp of when the moderator activated Shield Mode. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }
    }
}
