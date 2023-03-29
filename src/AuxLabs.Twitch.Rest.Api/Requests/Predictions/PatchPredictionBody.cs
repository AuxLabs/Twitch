using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class PatchPredictionBody : IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:predictions" };

        /// <summary> The ID of the broadcaster that’s running the prediction. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the prediction to update. </summary>
        [JsonPropertyName("id")]
        public string PredictionId { get; set; }

        /// <summary> The status to set the prediction to. </summary>
        [JsonPropertyName("status")]
        public PredictionStatus Status { get; set; }

        /// <summary> The ID of the winning outcome. </summary>
        [JsonPropertyName("winning_outcome_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WinningId { get; set; } = null;

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(PredictionId, nameof(PredictionId));
            if (Status == PredictionStatus.Resolved)
                Require.NotNullOrWhitespace(WinningId, nameof(WinningId));
        }
    }
}
