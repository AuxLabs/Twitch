using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostPredictionArgs : IScopedRequest
    {
        public string[] Scopes { get; } = { "channel:manage:predictions" };

        /// <summary> The ID of the broadcaster that’s running the prediction. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The question that the broadcaster is asking. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The list of possible outcomes that the viewers may choose from. </summary>
        [JsonPropertyName("outcomes")]
        public List<Title> Outcomes { get; set; }

        /// <summary> The length of time (in seconds) that the prediction will run for. </summary>
        [JsonPropertyName("prediction_window")]
        public int PredictionDurationSeconds { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(Title, nameof(Title));
            Require.NotNull(Outcomes, nameof(Outcomes));
            Require.HasAtLeast(Outcomes, 2, nameof(Outcomes));
            Require.HasAtMost(Outcomes, 10, nameof(Outcomes));
            Require.AtLeast(PredictionDurationSeconds, 30, nameof(PredictionDurationSeconds));
            Require.AtMost(PredictionDurationSeconds, 1800, nameof(PredictionDurationSeconds));
        }
    }
}
