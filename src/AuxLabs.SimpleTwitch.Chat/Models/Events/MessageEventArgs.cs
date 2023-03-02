using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class MessageEventArgs : IChatUserRelation, IChannel
    {
        /// <summary> If special characters are present, emote indices will be incorrect. </summary>
        public readonly bool ContainsSpecialCharacters;

        public MessageTags Tags { get; internal set; }
        public string ChannelName { get; internal set; }
        public string UserName { get; internal set; }
        public string Message { get; internal set; }

        public MessageEventArgs(IrcPrefix? prefix, IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault()[1..];
            UserName = prefix?.Username;
            ContainsSpecialCharacters = new StringInfo(Message).LengthInTextElements < Message.Length;
        }

        public static MessageEventArgs Create(IrcPayload payload)
        {
            var args = new MessageEventArgs(payload.Prefix, payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (MessageTags)payload.Tags;
            return args;
        }

        string IEntity<string>.Id { get => Tags.Id; }
        Color? IChatUser.Color { get => Tags.Color; }
        string IUser.Name { get => UserName; }
        string IUser.DisplayName { get => Tags.DisplayName; }
        string IChannel.Name { get => ChannelName; }
        string IUserRelation.RelatedId { get => Tags.ReplyParentUserId; }
        string IUserRelation.RelatedName { get => Tags.ReplyParentUserName; }
        string IUserRelation.RelatedDisplayName { get => Tags.ReplyParentDisplayName; }
    }
}
