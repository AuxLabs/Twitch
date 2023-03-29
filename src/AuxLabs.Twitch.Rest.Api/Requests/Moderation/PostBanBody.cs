using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostBanBody
    {
        /// <summary> Identifies the user and type of ban. </summary>
        [JsonPropertyName("data")]
        public PostBanUser[] Bans { get; set; }

        public void Validate()
        {
            Require.NotNull(Bans, nameof(Bans));
            Require.HasAtLeast(Bans, 1, nameof(Bans));
            foreach (var item in Bans)
                item.Validate();
        }
    }

    public class PostBanUser
    {
        /// <summary> The ID of the user to ban or put in a timeout. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The timeout period. </summary>
        /// <remarks> The minimum timeout is 1 second and the maximum is 1,209,600 seconds (2 weeks). </remarks>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DurationSeconds { get; set; }

        /// <summary> The reason the you’re banning the user or putting them in a timeout. </summary>
        /// <remarks> Limited to a maximum of 500 characters. </remarks>
        [JsonPropertyName("reason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Reason { get; set; }

        public PostBanUser() { }
        public PostBanUser(string userId, int? durationSeconds = null, string reason = null)
            => (UserId, DurationSeconds, Reason) = (userId, durationSeconds, reason);

        public void Validate()
        {
            Require.NotNullOrWhitespace(UserId, nameof(UserId));
            Require.AtLeast(DurationSeconds, 1, nameof(DurationSeconds));
            Require.AtMost(DurationSeconds, 1209600, nameof(DurationSeconds));
            Require.NotEmptyOrWhitespace(Reason, nameof(Reason));
            Require.LengthAtMost(Reason, 500, nameof(Reason));
        }
    }
}
