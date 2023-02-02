﻿using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CharityDonation
    {
        /// <summary> An ID that identifies the donation. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> An ID that identifies the charity campaign that the donation applies to. </summary>
        [JsonPropertyName("campaign_id")]
        public string CampaignId { get; set; }

        /// <summary> An ID that identifies a user that donated money to the campaign. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary> The amount of money that the user donated. </summary>
        [JsonPropertyName("amount")]
        public CharityAmount Amount { get; set; }
    }
}