using AuxLabs.SimpleTwitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class BaseRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("condition")]
        public IEventCondition Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("transport")]
        public Transport Transport { get; set; }
    }
}
