﻿using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class User
    {
        /// <summary>
        /// User’s broadcaster type
        /// </summary>
        [JsonPropertyName("broadcaster_type")]
        [JsonConverter(typeof(NullableEnumStringConverter<BroadcasterType>))]
        public BroadcasterType BroadcasterType { get; set; }

        /// <summary>
        /// User’s channel description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// User’s display name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// User’s ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// User’s login name
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }

        /// <summary>
        /// URL of the user’s offline image
        /// </summary>
        [JsonPropertyName("offline_image_url")]
        public string OfflineImageUrl { get; set; }

        /// <summary>
        /// URL of the user’s profile image
        /// </summary>
        [JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// User’s type
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(NullableEnumStringConverter<UserType>))]
        public UserType Type { get; set; }

        /// <summary>
        /// Total number of views of the user’s channel
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// User’s verified email address
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date when the user was created
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

    }
}
