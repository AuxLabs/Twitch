using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Subscription : SimpleSubscription
    {
        /// <summary> The name of the subscription. </summary>
        [JsonInclude, JsonPropertyName("plan_name")]
        public string PlanName { get; internal set; }

        /// <summary> An ID that identifies the subscribing user. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }
    }
}
