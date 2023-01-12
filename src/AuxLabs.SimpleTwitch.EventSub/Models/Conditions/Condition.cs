namespace AuxLabs.SimpleTwitch.EventSub.Models
{
    public class Condition
    {
        [JsonPropertyName("broadcaster_user_id")]
        public string Id { get; set; }
    }
}
