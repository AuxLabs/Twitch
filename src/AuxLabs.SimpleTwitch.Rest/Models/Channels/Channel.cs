using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Channel
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        [JsonPropertyName("game_name")]
        public string GameName { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("delay")]
        public int Delay { get; set; }

        public Channel(
            string broadcasterId,
            string broadcasterLogin,
            string broadcasterName,
            string broadcasterLanguage,
            string gameId,
            string gameName,
            string title,
            int delay)
            => (BroadcasterId, BroadcasterLogin, BroadcasterName, BroadcasterLanguage, GameId, GameName, Title, Delay)
            = (broadcasterId, broadcasterLogin, broadcasterName, broadcasterLanguage, gameId, gameName, title, delay);
    }
}
