using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PredictionUser
    {
        /// <summary> An ID that identifies the viewer. </summary>
        [JsonPropertyName("user_id")]
        public string Id { get; set; }

        /// <summary> The viewer’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string Name { get; set; }

        /// <summary> The viewer’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string DisplayName { get; set; }

        /// <summary> The number of Channel Points the viewer spent. </summary>
        [JsonPropertyName("channel_points_used")]
        public int ChannelPointsUsed { get; set; }

        /// <summary> The number of Channel Points distributed to the viewer. </summary>
        [JsonPropertyName("channel_points_won")]
        public int ChannelPointsWon { get; set; }
    }
}
