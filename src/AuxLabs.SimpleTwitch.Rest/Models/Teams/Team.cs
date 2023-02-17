using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Team : SimpleTeam
    {
        /// <summary> The list of team members. </summary>
        [JsonPropertyName("users")]
        public IReadOnlyCollection<TeamUser> Users { get; set; }
    }
}
