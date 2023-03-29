using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Team : SimpleTeam
    {
        /// <summary> The list of team members. </summary>
        [JsonInclude, JsonPropertyName("users")]
        public IReadOnlyCollection<TeamUser> Users { get; internal set; }
    }
}
