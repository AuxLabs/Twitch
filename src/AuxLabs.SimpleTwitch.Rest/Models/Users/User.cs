using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public record class User
    {
        /// <summary>
        /// User’s broadcaster type
        /// </summary>
        [JsonPropertyName("broadcaster_type")]
        [JsonConverter(typeof(Net.NullableEnumStringConverter<BroadcasterType>))]
        public BroadcasterType BroadcasterType { get; init; } = default;

        /// <summary>
        /// User’s channel description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; } = default!;

        /// <summary>
        /// User’s display name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; } = default!;

        /// <summary>
        /// User’s ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; } = default!;

        /// <summary>
        /// User’s login name
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; init; } = default!;

        /// <summary>
        /// URL of the user’s offline image
        /// </summary>
        [JsonPropertyName("offline_image_url")]
        public string OfflineImageUrl { get; init; } = default!;

        /// <summary>
        /// URL of the user’s profile image
        /// </summary>
        [JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; init; } = default!;

        /// <summary>
        /// User’s type
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(Net.NullableEnumStringConverter<UserType>))]
        public UserType Type { get; init; } = default;

        /// <summary>
        /// Total number of views of the user’s channel
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; init; } = default!;

        /// <summary>
        /// User’s verified email address
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; } = default!;

        /// <summary>
        /// Date when the user was created
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; init; }

    }
}
