using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GlobalEmote
    {
        /// <summary> An ID that identifies this emote. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The name of the emote. </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary> The image URLs for the emote. </summary>
        /// <remarks> These image URLs always provide a static, non-animated emote image with a light background. </remarks>
        [JsonPropertyName("images")]
        public TwitchImage Images { get; set; }

        /// <summary> The formats that the emote is available in. </summary>
        [JsonPropertyName("format")]
        public IReadOnlyCollection<EmoteFormat> Formats { get; set; }

        /// <summary> The sizes that the emote is available in. </summary>
        [JsonPropertyName("scale")]
        public IReadOnlyCollection<EmoteScale> Scales { get; set; }

        /// <summary> The background themes that the emote is available in. </summary>
        [JsonPropertyName("theme_mode")]
        public IReadOnlyCollection<EmoteTheme> Themes { get; set; }
    }
}
