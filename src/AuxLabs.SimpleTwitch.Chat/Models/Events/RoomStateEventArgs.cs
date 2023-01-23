namespace AuxLabs.SimpleTwitch.Chat.Models
{
    public class RoomStateEventArgs
    {
        public RoomStateTags Tags { get; set; }
        public string ChannelName { get; set; }

        public RoomStateEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
        }
    }
}
