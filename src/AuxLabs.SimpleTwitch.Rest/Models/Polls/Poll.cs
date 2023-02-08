using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Poll
    {
        /// <summary> An ID that identifies the poll. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> An ID that identifies the broadcaster that created the poll. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The question that viewers are voting on. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> A list of choices that viewers can choose from. </summary>
        [JsonPropertyName("choices")]
        public IReadOnlyCollection<PollOption> Choices { get; set; }

        /// <summary> Not used; will be set to false. </summary>
        [JsonPropertyName("bits_voting_enabled")]
        public bool IsBitsVotingEnabled { get; set; }

        /// <summary> Not used; will be set to 0. </summary>
        [JsonPropertyName("bits_per_vote")]
        public int BitsPerVote { get; set; }

        /// <summary> Indicates whether viewers may cast additional votes using Channel Points. </summary>
        [JsonPropertyName("channel_points_voting_enabled")]
        public bool IsChannelPointsVotingEnabled { get; set; }

        /// <summary> The number of points the viewer must spend to cast one additional vote. </summary>
        [JsonPropertyName("channel_points_per_vote")]
        public int ChannelPointsPerVote { get; set; }

        /// <summary> The poll’s status. </summary>
        [JsonPropertyName("status")]
        public PollStatus Status { get; set; }

        /// <summary> The length of time that the poll will run for. </summary>
        [JsonPropertyName("duration")]
        public int DurationSeconds { get; set; }

        /// <summary> The UTC date and time of when the poll began. </summary>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        /// <summary> The UTC date and time of when the poll ended. </summary>
        [JsonPropertyName("ended_at")]
        public DateTime? EndedAt { get; set; }
    }
}
