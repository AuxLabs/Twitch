using AuxLabs.Twitch.Rest;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class PollEventArgs
    {
        /// <summary> ID of the poll. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> Question displayed for the poll. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> A collection of choices for the poll. </summary>
        [JsonInclude, JsonPropertyName("choices")]
        public IReadOnlyCollection<PollOption> Choices { get; internal set; }

        /// <summary> The Bits voting settings for the poll. </summary>
        [JsonInclude, JsonPropertyName("bits_voting")]
        public VotingOption BitsVoting { get; internal set; }

        /// <summary> The Channel Points voting settings for the poll. </summary>
        [JsonInclude, JsonPropertyName("channel_points_voting")]
        public VotingOption ChannelPointsVoting { get; internal set; }

        /// <summary> The time the poll started. </summary>
        [JsonInclude, JsonPropertyName("started_at")]
        public DateTime StartedAt { get; internal set; }

        /// <summary> The time the poll will end. </summary>
        [JsonInclude, JsonPropertyName("ends_at")]
        public DateTime EndsAt { get; internal set; }
    }
}
