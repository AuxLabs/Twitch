using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostSegmentBody
    {
        /// <summary> The date and time that the broadcast segment starts. </summary>
        [JsonPropertyName("start_time")]
        public DateTime StartsAt { get; set; }

        /// <summary> The time zone that the broadcaster broadcasts from. </summary>
        /// <remarks> Specify the time zone using <see href="https://www.iana.org/time-zones">IANA time zone database</see> format </remarks>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        /// <summary> The length of time that the broadcast is scheduled to run. </summary>
        [JsonPropertyName("duration")]
        public string DurationMinutes { get; set; }

        /// <summary> Determines whether the broadcast recurs weekly. </summary>
        [JsonPropertyName("is_recurring")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsRecurring { get; set; }

        /// <summary> The ID of the category that best represents the broadcast’s content. </summary>
        [JsonPropertyName("category_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CategoryId { get; set; } = null;

        /// <summary> The broadcast’s title. </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; } = null;

        public void Validate()
        {
            Require.NotNullOrWhitespace(Timezone, nameof(Timezone));
            Require.NotNullOrWhitespace(DurationMinutes, nameof(DurationMinutes));

            Require.NotEmptyOrWhitespace(CategoryId, nameof(CategoryId));
            Require.NotEmptyOrWhitespace(Title, nameof(Title));
        }
    }
}
