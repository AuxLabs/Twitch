namespace AuxLabs.SimpleTwitch.Chat
{
    public class IrcMessage<TTags> where TTags : IDictionary<string, string>
    {
        public TTags Tags { get; set; }
        public string Prefix { get; set; }
        public IrcCommand Command { get; set; }
        public string CommandRaw { get; set; }
        public string Parameters { get; set; }

        public IrcMessage() { }
        public IrcMessage(IrcCommand ircCommand, string parameters)
            : this(null, ircCommand, parameters) { }
        public IrcMessage(string prefix, IrcCommand ircCommand, string parameters)
        {
            Prefix = prefix;
            Command = ircCommand;
            Parameters = parameters;
        }
    }

    // Provide a generic dictionary implementation for when Tag type isn't known, or isn't needed to be known
    public class IrcMessage : IrcMessage<Dictionary<string, string>>
    {
        public IrcMessage() { }
        public IrcMessage(IrcCommand ircCommand, string parameters)
            : base(ircCommand, parameters) { }
        public IrcMessage(string prefix, IrcCommand ircCommand, string parameters)
            : base(prefix, ircCommand, parameters) { }
    }
}
