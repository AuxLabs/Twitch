namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class PostChannelCommercialParams : IRequest
    {
        public string[] Scopes { get; } = { "channel:edit:commercial" };

        public string BroadcasterId { get; set; }
        public int Length { get; set; }

        public PostChannelCommercialParams(string broadcasterId, int length)
            => (BroadcasterId, Length) = (broadcasterId, length);

    }
}
