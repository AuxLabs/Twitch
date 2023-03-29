using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class Artist
    {
        /// <summary> The ID of the Twitch user that created the track. </summary>
        [JsonInclude, JsonPropertyName("creator_channel_id")]
        public string UserId { get; internal set; }

        /// <summary> The artist’s Amazon Standard Identification Number. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The artist’s name. </summary>
        [JsonInclude, JsonPropertyName("name")]
        public string Name { get; internal set; }
    }
}
