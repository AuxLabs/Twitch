using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class MockMessage
    {
        /// <summary> A caller-defined ID used to correlate this message with the same message in the response. </summary>
        [JsonPropertyName("msg_id")]
        public string Id { get; set; }

        /// <summary> The message to check. </summary>
        [JsonPropertyName("msg_text")]
        public string Text { get; set; }

        /// <summary> indicates whether Twitch would approve the message or hold it for moderator review. </summary>
        [JsonPropertyName("is_permitted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsPermitted { get; set; }

        public MockMessage() { }
        public MockMessage(string id, string text)
            => (Id, Text) = (id, text);
    }
}
