﻿using AuxLabs.Twitch.Rest.Models;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Cost
    {
        /// <summary> The amount exchanged for the digital product. </summary>
        [JsonInclude, JsonPropertyName("amount")]
        public int Amount { get; internal set; }

        /// <summary> The type of currency exchanged. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public CostType Type { get; internal set; }
    }
}