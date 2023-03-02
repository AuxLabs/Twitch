using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GlobalEmote
    {
        /// <summary> An ID that identifies this emote. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The name of the emote. </summary>
        [JsonInclude, JsonPropertyName("name")]
        public string Name { get; internal set; }

        /// <summary> The image URLs for the emote. </summary>
        /// <remarks> These image URLs always provide a static, non-animated emote image with a light background. </remarks>
        [JsonInclude, JsonPropertyName("images")]
        public TwitchImage Images { get; internal set; }

        /// <summary> The formats that the emote is available in. </summary>
        [JsonInclude, JsonPropertyName("format")]
        public IReadOnlyCollection<EmoteFormat> Formats { get; internal set; }

        /// <summary> The sizes that the emote is available in. </summary>
        [JsonInclude, JsonPropertyName("scale")]
        public IReadOnlyCollection<EmoteScale> Scales { get; internal set; }

        /// <summary> The background themes that the emote is available in. </summary>
        [JsonInclude, JsonPropertyName("theme_mode")]
        public IReadOnlyCollection<EmoteTheme> Themes { get; internal set; }
    }
}
