using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchChatSettingsArgs : IScoped
    {
        [JsonIgnore]
        public string[] Scopes { get; } = new[] { "moderator:manage:chat_settings" };

        /// <summary> Determines whether chat messages must contain only emotes. </summary>
        [JsonPropertyName("emote_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsEmoteOnly { get; set; }

        /// <summary> Determines whether the broadcaster restricts the chat room to followers only. </summary>
        [JsonPropertyName("follower_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsFollowerOnly { get; set; }

        /// <summary> The length of time that users must follow the broadcaster before being able to participate in the chat. </summary>
        [JsonPropertyName("follower_mode_duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int FollowerOnlyMinutes { get; set; }

        /// <summary> Determines whether the broadcaster adds a short delay before chat messages appear in the chat room. </summary>
        [JsonPropertyName("non_moderator_chat_delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsModeratorDelayed { get; set; }

        /// <summary> The amount of time that messages are delayed before appearing in chat. </summary>
        [JsonPropertyName("non_moderator_chat_delay_duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int ModeratorDelaySeconds { get; set; }

        /// <summary> Determines whether the broadcaster limits how often users in the chat room are allowed to send messages. </summary>
        [JsonPropertyName("slow_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsSlowEnabled { get; set; }

        /// <summary> The amount of time that users must wait between sending messages. </summary>
        [JsonPropertyName("slow_mode_wait_time")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int SlowSeconds { get; set; }

        /// <summary> Determines whether only users that subscribe to the broadcaster’s channel may talk in the chat room. </summary>
        [JsonPropertyName("subscriber_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsSubscriberOnly { get; set; }

        /// <summary> Determines whether the broadcaster requires users to post only unique messages in the chat room. </summary>
        [JsonPropertyName("unique_chat_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsUniqueEnabled { get; set; }
    }
}
