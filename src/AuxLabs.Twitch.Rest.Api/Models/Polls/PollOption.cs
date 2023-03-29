using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class PollOption
    {
        /// <summary> An ID that identifies this choice. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The choice’s title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The total number of votes cast for this choice. </summary>
        [JsonInclude, JsonPropertyName("votes")]
        public int Votes { get; internal set; }

        /// <summary> The number of votes cast using Channel Points. </summary>
        [JsonInclude, JsonPropertyName("channel_points_votes")]
        public int ChannelPointsVotes { get; internal set; }

        /// <summary> Not used; will be set to 0. </summary>
        [JsonInclude, JsonPropertyName("bits_votes")]
        public int BitsVotes { get; internal set; }
    }
}
