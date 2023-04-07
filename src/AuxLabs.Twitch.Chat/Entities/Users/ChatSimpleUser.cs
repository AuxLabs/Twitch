using AuxLabs.Twitch.Rest.Entities;
using System.Drawing;
using System.Threading.Tasks;
using GlobalState = AuxLabs.Twitch.Chat.Models.GlobalUserStateTags;
using Raid = AuxLabs.Twitch.Chat.Models.RaidTags;
using UserState = AuxLabs.Twitch.Chat.Models.UserStateEventArgs;
using Whisper = AuxLabs.Twitch.Chat.Models.WhisperEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    /// <summary>  </summary>
    public class ChatSimpleUser : ChatEntity<string>, IChatUser
    {
        public string DisplayName { get; private set; }
        public string Name { get; private set; }
        public Color? Color { get; private set; }

        internal ChatSimpleUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        #region Create

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

        internal static ChatSimpleUser Create(TwitchChatClient twitch, Raid model)
        {
            var entity = new ChatSimpleUser(twitch, model.AuthorId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Raid model)
        {
            DisplayName = model.RaiderDisplayName;
            Name = model.RaiderLogin;
            Color = model.AuthorColor;
        }
        internal virtual void Update(Whisper model)
        {
            DisplayName = model.Tags.AuthorDisplayName;
            Name = model.SenderName;
            Color = model.Tags.AuthorColor;
        }
        internal virtual void Update(GlobalState model)
        {
            DisplayName = model.UserDisplayName;
            Name = model.UserDisplayName;
            Color = model.Color;
        }
        internal virtual void Update(UserState model)
        {
            DisplayName = model.Tags.UserDisplayName;
            Name = model.Tags.UserDisplayName;
            Color = model.Tags.Color;
        }

        #endregion

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
