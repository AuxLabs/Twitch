﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PatchPollBody : IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:polls" };

        /// <summary> The ID of the broadcaster that’s running the poll. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the poll to update. </summary>
        [JsonPropertyName("id")]
        public string PollId { get; set; }

        /// <summary> The status to set the poll to. </summary>
        [JsonPropertyName("status")]
        public PollStatus Status { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(PollId, nameof(PollId));
        }
    }
}