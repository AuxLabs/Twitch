using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class SimpleChatUser : SimpleUser
    {
        /// <summary> The color of the user's name in chat. </summary>
        [JsonInclude, JsonPropertyName("color")]
        public Color Color { get; internal set; }
    }
}
