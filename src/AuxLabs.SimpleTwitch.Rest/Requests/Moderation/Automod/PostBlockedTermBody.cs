using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostBlockedTermBody
    {
        /// <summary> The word or phrase to block from being used in the broadcaster’s chat room. </summary>
        /// <remarks> Terms may include a wildcard character <c>*</c>. 
        /// The wildcard character must appear at the beginning or end of a word or set of characters. 
        /// For example, <c>*foo</c> or <c>foo*</c>. </remarks>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        public PostBlockedTermBody() { }
        public PostBlockedTermBody(string text) 
            => Text = text; 

        public override string ToString() 
            => Text;

        public void Validate()
        {
            Require.NotNullOrWhitespace(Text, nameof(Text));
            Require.LengthAtLeast(Text, 2, nameof(Text));
            Require.LengthAtMost(Text, 500, nameof(Text));
        }

        public static implicit operator string(PostBlockedTermBody value) => value.ToString();
        public static implicit operator PostBlockedTermBody(string v) => new PostBlockedTermBody(v);
    }
}
