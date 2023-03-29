using AuxLabs.Twitch.Chat;
using AuxLabs.Twitch.Rest;
using System.Drawing;
using System.Threading.Tasks;
using GlobalState = AuxLabs.Twitch.Chat.Models.GlobalUserStateTags;
using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;
using UserState = AuxLabs.Twitch.Chat.Models.UserStateEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    /// <summary>  </summary>
    public class ChatSimpleUser : ChatEntity<string>, IChatUser
    {
        public string DisplayName { get; internal set; }
        public string Name { get; internal set; }
        public Color? Color { get; internal set; }

        internal ChatSimpleUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal static ChatSimpleUser Create(TwitchChatClient twitch, IChatMessage model, bool isReply = false)
        {
            string userId = isReply
                ? model.ReplyAuthorId 
                : model.AuthorId;

            if (userId == null)
                return null;

            var entity = new ChatSimpleUser(twitch, userId);
            entity.Update(model, isReply);
            return entity;
        }
        internal virtual void Update(IChatMessage model, bool isReply = false)
        {
            if (isReply)
            {
                DisplayName = model.ReplyAuthorDisplayName;
                Name = model.ReplyAuthorName;
            } else
            {
                DisplayName = model.AuthorDisplayName;
                Name = model.AuthorName;
                Color = model.AuthorColor;
            }
        }

        internal static ChatUser Create(TwitchChatClient twitch, GlobalState model)
        {
            var entity = new ChatUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(GlobalState model)
        {
            DisplayName = model.UserDisplayName;
            Name = model.UserDisplayName;
            Color = model.Color;
        }

        internal static ChatChannelUser Create(TwitchChatClient twitch, UserState model)
        {
            var entity = new ChatChannelUser(twitch, model.Tags.UserId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(UserState model)
        {
            DisplayName = model.Tags.UserDisplayName;
            Name = model.Tags.UserDisplayName;
            Color = model.Tags.Color;
        }

        public override string ToString()
            => $"{DisplayName ?? Name} ({Id})";

        /// <summary> Get more info about this user. </summary>
        public Task<RestUser> GetUserAsync()
            => Twitch.Rest.GetUserByIdAsync(Id);

        /// <summary> Get the channel associated with this user. </summary>
        public Task<RestChannel> GetChannelAsync()
            => Twitch.Rest.GetChannelAsync(Id);
    }
}
