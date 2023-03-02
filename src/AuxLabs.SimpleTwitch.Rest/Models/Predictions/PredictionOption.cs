using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PredictionOption
    {
        /// <summary> An ID that identifies this outcome. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The outcome’s text. </summary>
        [JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The number of unique viewers that chose this outcome. </summary>
        [JsonPropertyName("users")]
        public int Users { get; internal set; }

        /// <summary> The number of Channel Points spent by viewers on this outcome. </summary>
        [JsonPropertyName("channel_points")]
        public int ChannelPointsTotal { get; internal set; }

        /// <summary> A collection of viewers who were the top predictors </summary>
        [JsonPropertyName("top_predictors")]
        public IReadOnlyCollection<PredictionUser> TopPredictors { get; internal set; }

        /// <summary> The color that visually identifies this outcome in the UX. </summary>
        [JsonPropertyName("color")]
        public PredictionColor Color { get; internal set; }
    }
}
