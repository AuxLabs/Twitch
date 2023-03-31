using System.Collections.Generic;
using GlobalState = AuxLabs.Twitch.Chat.Models.GlobalUserStateTags;
using UserState = AuxLabs.Twitch.Chat.Models.UserStateEventArgs;
using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;
using Whisper = AuxLabs.Twitch.Chat.Models.WhisperEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    /// <summary>  </summary>
    public class ChatUser : ChatSimpleUser
    {
        public UserType UserType { get; internal set; }
        public IReadOnlyCollection<Badge> Badges { get; internal set; }
        public string BadgeInfo { get; internal set; }
        public bool IsTurbo { get; internal set; }

        internal ChatUser(TwitchChatClient twitch, string id)
        : base(twitch, id) { }

        internal static ChatUser Create(TwitchChatClient twitch, Message model, bool isReply = false)
        {
            string userId = isReply
                ? model.Tags.ReplyAuthorId
                : model.Tags.AuthorId;

            if (userId == null)
                return null;

            var entity = new ChatUser(twitch, userId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Message model, bool isReply = false)
        {
            base.Update(model, isReply);
            UserType = model.Tags.AuthorType;
            Color = model.Tags.AuthorColor;
            Badges = model.Tags.Badges;
            BadgeInfo = model.Tags.BadgeInfo;
            IsTurbo = model.Tags.IsTurbo;
        }

        internal static ChatUser Create(TwitchChatClient twitch, Whisper model)
        {
            var entity = new ChatUser(twitch, model.Tags.AuthorId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Whisper model)
        {
            base.Update(model);
            UserType = model.Tags.AuthorType;
            Color = model.Tags.AuthorColor;
            Badges = model.Tags.Badges;
            IsTurbo = model.Tags.IsTurbo;
        }

        internal new static ChatUser Create(TwitchChatClient twitch, GlobalState model)
        {
            var entity = new ChatUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(GlobalState model)
        {
            base.Update(model);
            UserType = model.UserType;
            Color = model.Color;
            Badges = model.Badges;
            BadgeInfo = model.BadgeInfo;
            IsTurbo = model.IsTurbo;
        }

        internal new static ChatChannelUser Create(TwitchChatClient twitch, UserState model)
        {
            var entity = new ChatChannelUser(twitch, model.Tags.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(UserState model)
        {
            base.Update(model);
            UserType = model.Tags.UserType;
            Color = model.Tags.Color;
            Badges = model.Tags.Badges;
            BadgeInfo = model.Tags.BadgeInfo;
            IsTurbo = model.Tags.IsTurbo;
        }
    }
}
