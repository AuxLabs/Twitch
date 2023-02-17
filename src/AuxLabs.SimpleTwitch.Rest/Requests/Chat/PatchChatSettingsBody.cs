using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchChatSettingsBody
    {
        /// <summary> Determines whether chat messages must contain only emotes. </summary>
        [JsonPropertyName("emote_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsEmoteOnly { get; set; } = null;

        /// <summary> Determines whether the broadcaster restricts the chat room to followers only. </summary>
        [JsonPropertyName("follower_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsFollowerOnly { get; set; } = null;

        /// <summary> The length of time that users must follow the broadcaster before being able to participate in the chat. </summary>
        /// <remarks> Minimum value is 0, maximum is 129600 (3 months).  </remarks>
        [JsonPropertyName("follower_mode_duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FollowerOnlyMinutes { get; set; } = null;

        /// <summary> Determines whether the broadcaster adds a short delay before chat messages appear in the chat room. </summary>
        [JsonPropertyName("non_moderator_chat_delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsModeratorDelayed { get; set; } = null;

        /// <summary> The amount of time that messages are delayed before appearing in chat. </summary>
        /// <remarks> Can only be set to 2, 4, or 6. </remarks>
        [JsonPropertyName("non_moderator_chat_delay_duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ModeratorDelaySeconds { get; set; } = null;

        /// <summary> Determines whether the broadcaster limits how often users in the chat room are allowed to send messages. </summary>
        [JsonPropertyName("slow_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsSlowEnabled { get; set; } = null;

        /// <summary> The amount of time that users must wait between sending messages. </summary>
        /// <remarks> Minimum value is 3, maximum is 120. </remarks>
        [JsonPropertyName("slow_mode_wait_time")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SlowSeconds { get; set; } = null;

        /// <summary> Determines whether only users that subscribe to the broadcaster’s channel may talk in the chat room. </summary>
        [JsonPropertyName("subscriber_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsSubscriberOnly { get; set; } = null;

        /// <summary> Determines whether the broadcaster requires users to post only unique messages in the chat room. </summary>
        [JsonPropertyName("unique_chat_mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsUniqueEnabled { get; set; } = null;

        public void Validate()
        { 
            if (FollowerOnlyMinutes != null) IsFollowerOnly = true;
            Require.AtLeast(FollowerOnlyMinutes, 0, nameof(FollowerOnlyMinutes));
            Require.AtMost(FollowerOnlyMinutes, 129600, nameof(FollowerOnlyMinutes));

            if (ModeratorDelaySeconds != null) IsModeratorDelayed = true;
            Require.AtLeast(ModeratorDelaySeconds, 2, nameof(ModeratorDelaySeconds));
            Require.AtMost(ModeratorDelaySeconds, 6, nameof(ModeratorDelaySeconds));
            
            if (SlowSeconds != null) IsSlowEnabled = true;
            Require.AtLeast(SlowSeconds, 3, nameof(SlowSeconds));
            Require.AtMost(SlowSeconds, 120, nameof(SlowSeconds));
        }
    }
}
