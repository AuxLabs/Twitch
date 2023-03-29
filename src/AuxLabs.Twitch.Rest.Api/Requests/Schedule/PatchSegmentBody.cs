using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class PatchSegmentBody
    {
        /// <summary> The date and time that the broadcast segment starts. </summary>
        [JsonPropertyName("start_time")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? StartsAt { get; set; } = null;

        /// <summary> The length of time that the broadcast is scheduled to run. </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DurationMinutes { get; set; } = null;

        /// <summary> The ID of the category that best represents the broadcast’s content. </summary>
        [JsonPropertyName("category_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CategoryId { get; set; } = null;

        /// <summary> The broadcast’s title. </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; } = null;

        /// <summary> Indicates whether the broadcast is canceled. </summary>
        [JsonPropertyName("is_canceled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsCancelled { get; set; } = null;

        /// <summary> The time zone that the broadcaster broadcasts from. </summary>
        /// <remarks> Specify the time zone using <see href="https://www.iana.org/time-zones">IANA time zone database</see> format </remarks>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = null;

        public void Validate()
        {
            Require.NotEmptyOrWhitespace(Timezone, nameof(Timezone));
            Require.NotEmptyOrWhitespace(DurationMinutes, nameof(DurationMinutes));
            Require.NotEmptyOrWhitespace(CategoryId, nameof(CategoryId));
            Require.NotEmptyOrWhitespace(Title, nameof(Title));
        }
    }
}
