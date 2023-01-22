using AuxLabs.SimpleTwitch.Chat.Models;
using System.Text;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class IrcPayload
    {
        public BaseTags Tags { get; set; } = null;
        public IrcPrefix? Prefix { get; set; } = null;
        public IrcCommand Command { get; set; }
        public string CommandRaw { get; set; }
        public IReadOnlyCollection<string> Parameters { get; set; }

        public IrcPayload() { }
        public IrcPayload(IrcCommand ircCommand, params string[] parameters)
            : this(null, ircCommand, parameters) { }
        public IrcPayload(string prefix, IrcCommand ircCommand, params string[] parameters)
        {
            if (prefix != null)
                Prefix = new IrcPrefix(prefix);
            Command = ircCommand;
            Parameters = parameters;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Tags != null)
            {
                builder.Append('@');
                foreach (var tag in Tags.CreateQueryMap())
                    builder.Append($";{tag.Key}={tag.Value}");
                builder.Append(' ');
            }

            if (Prefix != null)
                builder.Append($"{Prefix} ");

            var commandRaw = CommandRaw ?? Command.GetEnumMemberValue();
            builder.Append(commandRaw);
            if (Parameters.Count > 0)
                builder.Append($" {string.Join(' ', Parameters)}");
            return builder.ToString();
        }

        public static Dictionary<IrcCommand, Type> CommandTypeSelector => new()
        {
            [IrcCommand.ClearChat] = typeof(ClearChatTags),
            [IrcCommand.ClearMessage] = typeof(ClearMessageTags),
            [IrcCommand.Message] = typeof(MessageTags),

            //[IrcCommand.Mode] = typeof(BaseTags),
            //[IrcCommand.Names] = typeof(BaseTags),
            //[IrcCommand.NamesList] = typeof(BaseTags),
            //[IrcCommand.NamesEnd] = typeof(BaseTags),
            [IrcCommand.Notice] = typeof(NoticeTags),
            //[IrcCommand.Reconnect] = typeof(BaseTags),
            [IrcCommand.RoomState] = typeof(RoomStateTags),
            //[IrcCommand.UserNotice] = typeof(BaseTags),
            //[IrcCommand.UserState] = typeof(BaseTags),
            [IrcCommand.GlobalUserState] = typeof(GlobalUserStateTags),
            //[IrcCommand.CapabilityAcknowledge] = typeof(BaseTags),
            //[IrcCommand.CapabilityDenied] = typeof(BaseTags)
        };
    }
}
