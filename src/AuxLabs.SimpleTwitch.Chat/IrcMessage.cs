namespace AuxLabs.SimpleTwitch.Chat
{
    public class IrcMessage
    {
        public Dictionary<string, string> Tags { get; set; } = null;
        public string Prefix { get; set; }
        public IrcCommand Command { get; set; }
        public string CommandRaw { get; set; }
        public List<string> Parameters { get; set; }

        public IrcMessage(string prefix, IrcCommand ircCommand, params string[] parameters)
        {
            Prefix = prefix;
            Command = ircCommand;
            Parameters = new List<string>(parameters);
        }
    }
}
