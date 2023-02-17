using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Subscription : SimpleSubscription
    {
        /// <summary> The name of the subscription. </summary>
        [JsonPropertyName("plan_name")]
        public string PlanName { get; set; }

        /// <summary> An ID that identifies the subscribing user. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; set; }
    }
}
