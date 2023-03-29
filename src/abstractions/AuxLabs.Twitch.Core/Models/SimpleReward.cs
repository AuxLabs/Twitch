using System.Text.Json.Serialization;

namespace AuxLabs.Twitch
{
    public class SimpleReward
    {
        /// <summary> The ID that uniquely identifies this custom reward. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The title of the reward. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The prompt shown to the viewer when they redeem the reward if user input is required. </summary>
        [JsonInclude, JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary> The cost of the reward in channel points. </summary>
        [JsonInclude, JsonPropertyName("cost")]
        public int Cost { get; set; }

    }
}
