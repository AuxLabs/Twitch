using Newtonsoft.Json;

namespace AuxLabs.SimpleTwitch.Rest.Entities
{
    public class ChannelEditor
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
