using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class WhisperEventArgs : IWhisperMessage
    {
        public WhisperTags Tags { get; internal set; }
        public string SenderName { get; internal set; }
        public string ReceiverName { get; internal set; }
        public string Message { get; internal set; }

        public WhisperEventArgs(IrcPrefix? prefix, IReadOnlyCollection<string> parameters)
        {
            SenderName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault().Trim(':');
            ReceiverName = prefix?.Username;
        }

        public static WhisperEventArgs Create(IrcPayload payload)
        {
            var args = new WhisperEventArgs(payload.Prefix, payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (WhisperTags)payload.Tags;
            return args;
        }

        string IWhisperMessage.ThreadId => Tags.ThreadId;
        string IMessage.AuthorId => Tags.AuthorId;
        string IMessage.AuthorName => SenderName;
        string IMessage.AuthorDisplayName => Tags.AuthorDisplayName;
        UserType IMessage.AuthorType => Tags.AuthorType;
        Color IMessage.AuthorColor => Tags.AuthorColor;
        string IMessage.Content => Message;
        string IMessage.Action => Tags.Action;
        bool IMessage.IsTurbo => Tags.IsTurbo;
        IReadOnlyCollection<Badge> IMessage.Badges => Tags.Badges;
        IReadOnlyCollection<EmotePosition> IMessage.Emotes => Tags.Emotes;
        string IEntity<string>.Id => Tags.MessageId;
    }
}
