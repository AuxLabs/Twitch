using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class VotingOption
    {
        /// <summary> Indicates if this option is enabled. </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }

        /// <summary> Number of specified currency required to vote once. </summary>
        [JsonPropertyName("amount_per_vote")]
        public int AmountPerVote { get; set; }
    }
}
