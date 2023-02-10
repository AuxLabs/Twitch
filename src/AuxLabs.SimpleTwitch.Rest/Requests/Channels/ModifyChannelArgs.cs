﻿using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ModifyChannelArgs : IScoped
    {
        public string[] Scopes { get; } = { "channel:manage:broadcast" };

        /// <summary> The ID of the game that the user plays. </summary>
        [JsonPropertyName("game_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GameId { get; set; } = null;

        /// <summary> The user’s preferred language. Set the value to an ISO 639-1 two-letter language code. </summary>
        [JsonPropertyName("broadcaster_language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BroadcasterLanguage { get; set; } = null;

        /// <summary> The title of the user’s stream. </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; } = null;

        /// <summary> The number of seconds you want your broadcast buffered before streaming it live. </summary>
        /// <remarks> Only channels with Partner status can change this property. Max value is 900. </remarks>
        [JsonPropertyName("delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Delay { get; set; } = null;

        /// <summary> A collection of channel-defined tags to apply to the channel. </summary>
        /// <remarks>  </remarks>
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Tags { get; set; } = null;

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotEmptyOrWhitespace(Title, nameof(Title));
            Require.AtMost(Delay, 900, nameof(Delay));
            Require.HasAtMost(Tags, 10, nameof(Tags));
            if (Tags != null)
            {
                foreach (var tag in Tags)
                    Require.LengthAtMost(tag, 25, nameof(Tags));
            }
        }
    }
}
