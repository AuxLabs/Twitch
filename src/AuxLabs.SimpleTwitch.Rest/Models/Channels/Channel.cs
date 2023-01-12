using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public record class Channel
    {
        /// <summary>
        /// An ID that uniquely identifies the broadcaster.
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; init; }

        /// <summary>
        /// The broadcaster’s login name.
        /// </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; init; }

        /// <summary>
        /// The broadcaster’s display name.
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; init; }

        /// <summary>
        /// The broadcaster’s preferred language. The value is an ISO 639-1 two-letter language code.
        /// </summary>
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; init; }

        /// <summary>
        /// An ID that uniquely identifies the game that the broadcaster is playing or last played.
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; init; }

        /// <summary>
        /// The name of the game that the broadcaster is playing or last played.
        /// </summary>
        [JsonPropertyName("game_name")]
        public string GameName { get; init; }

        /// <summary>
        /// The title of the stream that the broadcaster is currently streaming or last streamed.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }

        /// <summary>
        /// The value of the broadcaster’s stream delay setting, in seconds.
        /// </summary>
        [JsonPropertyName("delay")]
        public uint Delay { get; init; }

        /// <summary>
        /// The tags applied to the channel.
        /// </summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; init; }
    }
}
