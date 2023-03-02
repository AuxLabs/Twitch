using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class ClearChatEventArgs : IChatUserRelation
    {
        /// <summary> The tags for this event, if provided. </summary>
        public ClearChatTags Tags { get; internal set; }

        /// <summary> The channel's name. </summary>
        public string ChannelName { get; internal set; }

        /// <summary> The user whose messages were cleared from chat.  </summary>
        public string UserName { get; internal set; }

        public ClearChatEventArgs(IReadOnlyCollection<string> parameters)
        {
            ChannelName = parameters.ElementAt(0).Trim('#');
            UserName = parameters.ElementAtOrDefault(1)?.Trim(':');
        }

        public static ClearChatEventArgs Create(IrcPayload payload)
        {
            var args = new ClearChatEventArgs(payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (ClearChatTags)payload.Tags;
            return args;
        }

        Color? IChatUser.Color => null;
        string IUserRelation.RelatedId => Tags.TargetUserId;
        string IUserRelation.RelatedName => UserName;
        string IUserRelation.RelatedDisplayName => null;
        string IUser.Name => ChannelName;
        string IUser.DisplayName => null;
        string IEntity<string>.Id => Tags.ChannelId;
    }
}
