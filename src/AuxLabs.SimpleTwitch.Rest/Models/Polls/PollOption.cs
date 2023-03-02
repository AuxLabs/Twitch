using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PollOption
    {
        /// <summary> An ID that identifies this choice. </summary>
        [JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The choice’s title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The total number of votes cast for this choice. </summary>
        [JsonPropertyName("votes")]
        public int Votes { get; internal set; }

        /// <summary> The number of votes cast using Channel Points. </summary>
        [JsonPropertyName("channel_points_votes")]
        public int ChannelPointsVotes { get; internal set; }

        /// <summary> Not used; will be set to 0. </summary>
        [JsonPropertyName("bits_votes")]
        public int BitsVotes { get; internal set; }
    }
}
