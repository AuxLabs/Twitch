﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class BadgeSet
    {
        /// <summary> An ID that identifies this set of chat badges. </summary>
        [JsonInclude, JsonPropertyName("set_id")]
        public string SetId { get; internal set; }

        /// <summary> A collection of chat badges in this set. </summary>
        [JsonInclude, JsonPropertyName("versions")]
        public IReadOnlyCollection<Badge> Versions { get; internal set; }
    }
}