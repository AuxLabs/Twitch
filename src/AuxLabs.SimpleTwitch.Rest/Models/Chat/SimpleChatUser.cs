using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class SimpleChatUser : SimpleUser
    {
        /// <summary> The color of the user's name in chat. </summary>
        [JsonPropertyName("color")]
        public Color Color { get; internal set; }
    }
}
