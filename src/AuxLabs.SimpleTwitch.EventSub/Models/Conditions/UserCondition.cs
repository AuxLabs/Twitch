﻿using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class UserCondition : ICondition
    {
        /// <summary> The user ID for the user you want notifications for. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        public UserCondition() { }
        public UserCondition(string userId)
        {
            UserId = userId;
        }
    }
}
