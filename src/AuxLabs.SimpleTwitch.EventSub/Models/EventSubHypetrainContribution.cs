using AuxLabs.SimpleTwitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubHypetrainContribution : HypeTrainContribution
    {
        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }
    }
}
