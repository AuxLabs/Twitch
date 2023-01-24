namespace AuxLabs.SimpleTwitch.Chat
{
    public class MembershipEventArgs
    {
        public string ChannelName { get; set; }
        public string UserName { get; set; }

        public MembershipEventArgs(IrcPrefix prefix, IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            UserName = prefix.Username;
        }
    }
}
