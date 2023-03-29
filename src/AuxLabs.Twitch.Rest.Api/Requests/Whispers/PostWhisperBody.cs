using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostWhisperBody
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        public PostWhisperBody() { }
        public PostWhisperBody(string message)
        {
            Message = message;
        }

        public override string ToString()
            => Message;

        public void Validate()
        {
            Require.NotNullOrWhitespace(Message, nameof(Message));
            Require.LengthAtLeast(Message, 1, nameof(Message));
            Require.LengthAtMost(Message, 10000, nameof(Message));
        }

        public static implicit operator string(PostWhisperBody value) => value.Message;
        public static implicit operator PostWhisperBody(string v) => new PostWhisperBody(v);
    }
}
