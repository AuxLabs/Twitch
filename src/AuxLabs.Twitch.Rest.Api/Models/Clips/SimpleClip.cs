using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class SimpleClip
    {
        /// <summary> An ID that uniquely identifies the clip. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A URL that you can use to edit the clip’s title, identify the part of the clip to publish, and publish the clip. </summary>
        [JsonInclude, JsonPropertyName("edit_url")]
        public string EditUrl { get; internal set; }
    }
}
