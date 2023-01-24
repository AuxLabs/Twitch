namespace AuxLabs.SimpleTwitch.Rest
{
    public class User
    {
        /// <summary>
        /// User’s broadcaster type
        /// </summary>
        [JsonPropertyName("broadcaster_type")]
        [JsonConverter(typeof(NullableEnumStringConverter<BroadcasterType>))]
        public BroadcasterType BroadcasterType { get; init; }

        /// <summary>
        /// User’s channel description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; }

        /// <summary>
        /// User’s display name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }

        /// <summary>
        /// User’s ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }

        /// <summary>
        /// User’s login name
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; init; }

        /// <summary>
        /// URL of the user’s offline image
        /// </summary>
        [JsonPropertyName("offline_image_url")]
        public string OfflineImageUrl { get; init; }

        /// <summary>
        /// URL of the user’s profile image
        /// </summary>
        [JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; init; }

        /// <summary>
        /// User’s type
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<UserType>))]
        public UserType Type { get; init; }

        /// <summary>
        /// Total number of views of the user’s channel
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; init; }

        /// <summary>
        /// User’s verified email address
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// Date when the user was created
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; init; }

    }
}
