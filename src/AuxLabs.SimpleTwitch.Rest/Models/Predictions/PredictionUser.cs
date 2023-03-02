using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PredictionUser
    {
        /// <summary> An ID that identifies the viewer. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string Id { get; internal set; }

        /// <summary> The viewer’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string Name { get; internal set; }

        /// <summary> The viewer’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string DisplayName { get; internal set; }

        /// <summary> The number of Channel Points the viewer spent. </summary>
        [JsonInclude, JsonPropertyName("channel_points_used")]
        public int ChannelPointsUsed { get; internal set; }

        /// <summary> The number of Channel Points distributed to the viewer. </summary>
        [JsonInclude, JsonPropertyName("channel_points_won")]
        public int ChannelPointsWon { get; internal set; }
    }
}
