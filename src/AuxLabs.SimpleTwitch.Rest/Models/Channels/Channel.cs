using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Channel : IUser, IChannel
    {
        /// <summary> An ID that uniquely identifies the broadcaster. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The broadcaster’s preferred language. The value is an ISO 639-1 two-letter language code. </summary>
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }

        /// <summary> An ID that uniquely identifies the game that the broadcaster is playing or last played. </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        /// <summary> The name of the game that the broadcaster is playing or last played. </summary>
        [JsonPropertyName("game_name")]
        public string GameName { get; set; }

        /// <summary> The title of the stream that the broadcaster is currently streaming or last streamed. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The value of the broadcaster’s stream delay setting, in seconds. </summary>
        [JsonPropertyName("delay")]
        public uint Delay { get; set; }

        /// <summary> The tags applied to the channel. </summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }

        string IUser.Name { get => BroadcasterDisplayName; }
        string IUser.DisplayName { get => BroadcasterDisplayName; }
        string IEntity<string>.Id { get => BroadcasterId; }
        string IChannel.Name { get => BroadcasterName; }
    }
}
