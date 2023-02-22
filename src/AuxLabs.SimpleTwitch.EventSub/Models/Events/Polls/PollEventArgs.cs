using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class PollEventArgs
    {
        /// <summary> ID of the poll. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> Question displayed for the poll. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> A collection of choices for the poll. </summary>
        [JsonPropertyName("choices")]
        public IReadOnlyCollection<PollOption> Choices { get; set; }

        /// <summary> The Bits voting settings for the poll. </summary>
        [JsonPropertyName("bits_voting")]
        public VotingOption BitsVoting { get; set; }

        /// <summary> The Channel Points voting settings for the poll. </summary>
        [JsonPropertyName("channel_points_voting")]
        public VotingOption ChannelPointsVoting { get; set; }

        /// <summary> The time the poll started. </summary>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        /// <summary> The time the poll will end. </summary>
        [JsonPropertyName("ends_at")]
        public DateTime EndsAt { get; set; }
    }
}
