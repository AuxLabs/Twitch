using System.Runtime.Serialization;
using System.Text;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class IrcMessage<TTags> where TTags : IDictionary<string, string>
    {
        public TTags Tags { get; set; }
        public IrcPrefix Prefix { get; set; }
        public IrcCommand Command { get; set; }
        public string CommandRaw { get; set; }
        public string Parameters { get; set; }

        public IrcMessage() { }
        public IrcMessage(IrcCommand ircCommand, string parameters)
            : this(null, ircCommand, parameters) { }
        public IrcMessage(string prefix, IrcCommand ircCommand, string parameters)
        {
            Prefix = new IrcPrefix(prefix);
            Command = ircCommand;
            Parameters = parameters;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Tags != null)
            {
                builder.Append("@");
                foreach (var tag in Tags)
                    builder.Append($";{tag.Key}={tag.Value}");
                builder.Append(' ');
            }

            // Prefix value in a sent message is constant, so custom values are ignored
            //builder.Append($":{TwitchConstants.ChatHost} ");

            var commandRaw = Command.GetEnumMemberValue();
            builder.Append($"{commandRaw} {Parameters}");
            return builder.ToString();
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
