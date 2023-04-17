﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Team : PartialTeam
    {
        /// <summary> The list of team members. </summary>
        [JsonInclude, JsonPropertyName("users")]
        public IReadOnlyCollection<TeamUser> Users { get; internal set; }
    }
}
