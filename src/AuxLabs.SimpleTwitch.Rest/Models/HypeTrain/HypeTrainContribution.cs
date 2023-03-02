using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class HypeTrainContribution
    {
        /// <summary> The total amount contributed. </summary>
        [JsonPropertyName("total")]
        public int Total { get; internal set; }

        /// <summary> The contribution method used. </summary>
        [JsonPropertyName("type")]
        public HypeTrainContributionType Type { get; internal set; }

        /// <summary> The ID of the user that made the contribution. </summary>
        [JsonPropertyName("user")]
        public string UserId { get; internal set; }
    }
}
