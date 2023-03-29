using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class PutPollBody : IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:polls" };

        /// <summary> The ID of the broadcaster that’s running the poll. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The question that viewers will vote on. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> A list of choices that viewers may choose from. </summary>
        [JsonPropertyName("choices")]
        public Title[] Choices { get; set; }

        /// <summary> The length of time that the poll will run for. </summary>
        [JsonPropertyName("duration")]
        public int DurationSeconds { get; set; }

        /// <summary> Optional. Indicates whether viewers may cast additional votes using Channel Points.  </summary>
        [JsonPropertyName("channel_points_voting_enabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsChannelPointsVotingEnabled { get; set; }

        /// <summary> Optional. The number of points that the viewer must spend to cast one additional vote. </summary>
        [JsonPropertyName("channel_points_per_vote")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ChannelPointsPerVote { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(Title, nameof(Title));
            Require.NotNull(Choices, nameof(Choices));
            Require.HasAtLeast(Choices, 2, nameof(Choices));
            Require.HasAtMost(Choices, 5, nameof(Choices));
            Require.AtLeast(DurationSeconds, 15, nameof(DurationSeconds));
            Require.AtMost(DurationSeconds, 1800, nameof(DurationSeconds));

            if (ChannelPointsPerVote != null)
                IsChannelPointsVotingEnabled = true;
            Require.AtLeast(ChannelPointsPerVote, 1, nameof(ChannelPointsPerVote));
            Require.AtMost(ChannelPointsPerVote, 1000000, nameof(ChannelPointsPerVote));
        }
    }
}
