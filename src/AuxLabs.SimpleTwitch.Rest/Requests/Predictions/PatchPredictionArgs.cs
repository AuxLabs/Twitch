using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchPredictionArgs : IScoped
    {
        public string[] Scopes { get; } = { "channel:manage:predictions" };

        /// <summary> The ID of the broadcaster that’s running the prediction. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the prediction to update. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The status to set the prediction to. </summary>
        [JsonPropertyName("status")]
        public PredictionStatus Status { get; set; }

        /// <summary> The ID of the winning outcome. </summary>
        [JsonPropertyName("winning_outcome_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WinningId { get; set; } = null;
    }
}
