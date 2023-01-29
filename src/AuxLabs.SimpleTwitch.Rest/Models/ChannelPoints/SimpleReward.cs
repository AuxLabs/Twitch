using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleReward
    {
        /// <summary> The ID that uniquely identifies this custom reward. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The title of the reward. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The prompt shown to the viewer when they redeem the reward if user input is required. </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary> The cost of the reward in channel points. </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }

    }
}
