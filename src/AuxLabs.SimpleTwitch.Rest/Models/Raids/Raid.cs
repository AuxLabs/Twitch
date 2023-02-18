﻿using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Raid
    {
        /// <summary> The UTC date and time of when the raid was requested. </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary> Indicates whether the channel being raided contains mature content. </summary>
        [JsonPropertyName("is_mature")]
        public bool IsMature { get; set; }
    }
}