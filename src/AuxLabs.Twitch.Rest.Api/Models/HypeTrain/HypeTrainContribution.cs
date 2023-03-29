using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class HypeTrainContribution
    {
        /// <summary> The total amount contributed. </summary>
        [JsonInclude, JsonPropertyName("total")]
        public int Total { get; internal set; }

        /// <summary> The contribution method used. </summary>
        [JsonInclude, JsonPropertyName("type")]
        public HypeTrainContributionType Type { get; internal set; }

        /// <summary> The ID of the user that made the contribution. </summary>
        [JsonInclude, JsonPropertyName("user")]
        public string UserId { get; internal set; }
    }
}
