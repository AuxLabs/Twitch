﻿using AuxLabs.Twitch.Rest.Models;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostEnforcementStatusBody
    {
        /// <summary> The list of messages to check. </summary>
        [JsonPropertyName("data")]
        public MockMessage[] Messages { get; set; }

        public void Validate()
        {
            Require.HasAtLeast(Messages, 1, nameof(Messages));
            Require.HasAtMost(Messages, 100, nameof(Messages));
        }
    }
}