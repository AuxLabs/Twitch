using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class MockMessage
    {
        /// <summary> A caller-defined ID used to correlate this message with the same message in the response. </summary>
        [JsonInclude, JsonPropertyName("msg_id")]
        public string Id { get; internal set; }

        /// <summary> The message to check. </summary>
        [JsonInclude, JsonPropertyName("msg_text")]
        public string Text { get; internal set; }

        /// <summary> Indicates whether Twitch would approve the message or hold it for moderator review. </summary>
        [JsonInclude, JsonPropertyName("is_permitted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsPermitted { get; internal set; }

        public MockMessage() { }
        public MockMessage(string id, string text)
            => (Id, Text) = (id, text);
    }
}
