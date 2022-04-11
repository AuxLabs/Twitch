using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public record class Channel
    {
        /// <summary>
        /// Twitch User ID of this channel owner.
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; init; } = default!;

        /// <summary>
        /// Broadcaster’s user login name.
        /// </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; init; } = default!;

        /// <summary>
        /// Twitch user display name of this channel owner.
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; init; } = default!;

        /// <summary>
        /// Language of the channel.
        /// </summary>
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; init; } = default!;

        /// <summary>
        /// Current game ID being played on the channel.
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; init; } = default!;

        /// <summary>
        /// Name of the game being played on the channel.
        /// </summary>
        [JsonPropertyName("game_name")]
        public string GameName { get; init; } = default!;

        /// <summary>
        /// Title of the stream.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; } = default!;

        /// <summary>
        /// Stream delay in seconds.
        /// </summary>
        [JsonPropertyName("delay")]
        public int Delay { get; init; } = default!;
    }
}
