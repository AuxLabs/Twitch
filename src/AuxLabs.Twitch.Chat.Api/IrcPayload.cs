using AuxLabs.Twitch.Chat.Models;
using AuxLabs.Twitch.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuxLabs.Twitch.Chat.Api
{
    public class IrcPayload : IPayload
    {
        // Irc doesn't have a hello event
        public bool IsHelloEvent => false;

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
                builder.Append(string.Join(';', Tags.CreateQueryMap().Select(x => $"{x.Key}={x.Value}")));
                builder.Append(' ');
            }

            if (Prefix != null)
                builder.Append($"{Prefix} ");

            var commandRaw = CommandRaw ?? Command.GetStringValue();
            builder.Append(commandRaw);
            if (Parameters.Count > 0)
                builder.Append($" {string.Join(' ', Parameters)}");
            return builder.ToString();
        }

        public static Dictionary<IrcCommand, Type> TagsTypeSelector => new Dictionary<IrcCommand, Type>()
        {
            [IrcCommand.ClearChat] = typeof(ClearChatTags),
            [IrcCommand.ClearMessage] = typeof(ClearMessageTags),
            [IrcCommand.GlobalUserState] = typeof(GlobalUserStateTags),
            [IrcCommand.Notice] = typeof(NoticeTags),
            [IrcCommand.Message] = typeof(MessageTags),
            [IrcCommand.RoomState] = typeof(RoomStateTags),
            [IrcCommand.UserNotice] = typeof(UserNoticeTags),
            [IrcCommand.UserState] = typeof(UserStateTags),
            [IrcCommand.Whisper] = typeof(WhisperTags)
        };

        public static Dictionary<UserNoticeType, Type> UserNoticeTypeSelector => new Dictionary<UserNoticeType, Type>()
        {
            [UserNoticeType.Subscription] = typeof(SubscriptionTags),
            [UserNoticeType.Resubscription] = typeof(SubscriptionTags),
            [UserNoticeType.SubscriptionGift] = typeof(SubscriptionGiftTags),
            [UserNoticeType.SubscriptionGiftUpgrade] = typeof(SubscriptionGiftUpgradeTags),
            [UserNoticeType.SubscriptionGiftUpgradeAnonymous] = typeof(SubscriptionGiftUpgradeAnonymousTags),

            [UserNoticeType.Raid] = typeof(RaidTags),
            [UserNoticeType.Ritual] = typeof(RitualTags),
            [UserNoticeType.BitsBadgeTier] = typeof(BitsBadgeTierTags),
        };
    }
}
