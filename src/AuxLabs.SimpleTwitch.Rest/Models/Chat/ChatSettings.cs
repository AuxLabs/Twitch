using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ChatSettings : PatchChatSettingsBody
    {
        /// <summary> The ID of the broadcaster specified in the request. </summary>
        [JsonPropertyName("broadcaster_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BroadcasterId { get; internal set; }

        /// <summary> The moderator’s ID. </summary>
        [JsonPropertyName("moderator_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ModeratorId { get; internal set; }
    }
}
