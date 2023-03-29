using AuxLabs.Twitch.Rest.Models;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class GoalEndedEventArgs : Goal
    {
        /// <summary> Indicates whether the broadcaster achieved their goal. </summary>
        [JsonInclude, JsonPropertyName("is_achieved")]
        public bool IsAchieved { get; internal set; }

        /// <summary> The UTC timestamp which indicates when the broadcaster ended the goal. </summary>
        [JsonInclude, JsonPropertyName("ended_at")]
        public bool EndedAt { get; internal set; }
    }
}
