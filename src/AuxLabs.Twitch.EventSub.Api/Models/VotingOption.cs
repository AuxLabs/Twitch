using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class VotingOption
    {
        /// <summary> Indicates if this option is enabled. </summary>
        [JsonInclude, JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; internal set; }

        /// <summary> Number of specified currency required to vote once. </summary>
        [JsonInclude, JsonPropertyName("amount_per_vote")]
        public int AmountPerVote { get; internal set; }
    }
}
