using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleClip
    {
        /// <summary> An ID that uniquely identifies the clip. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> A URL that you can use to edit the clip’s title, identify the part of the clip to publish, and publish the clip. </summary>
        [JsonPropertyName("edit_url")]
        public string EditUrl { get; set; }
    }
}
