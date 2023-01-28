using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ModifyChannelParams
    {
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
    }
}
