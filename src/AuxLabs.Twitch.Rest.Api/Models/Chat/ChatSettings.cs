using AuxLabs.Twitch.Rest.Requests;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class ChatSettings : PatchChatSettingsBody
    {
        /// <summary> The ID of the broadcaster specified in the request. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BroadcasterId { get; internal set; }

        /// <summary> The moderator’s ID. </summary>
        [JsonInclude, JsonPropertyName("moderator_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ModeratorId { get; internal set; }
    }
}
