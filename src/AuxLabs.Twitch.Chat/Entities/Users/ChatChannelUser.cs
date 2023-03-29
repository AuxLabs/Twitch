using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;
using UserState = AuxLabs.Twitch.Chat.Models.UserStateEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    /// <summary> Data for a user specific to certain channels </summary>
    public class ChatChannelUser : ChatUser
    {
        public ChatSimpleChannel Channel { get; internal set; }
        public bool IsModerator { get; internal set; }
        public bool IsSubscriber { get; internal set; }
        public bool? IsVIP { get; internal set; }

        internal ChatChannelUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal new static ChatChannelUser Create(TwitchChatClient twitch, Message model, bool isReply = false)
        {
            var userId = isReply 
                ? model.Tags.ReplyAuthorId 
                : model.Tags.AuthorId;

            var entity = new ChatChannelUser(twitch, userId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Message model, bool isReply = false)
        {
            base.Update(model, isReply);
            IsModerator = model.Tags.IsModerator;
            IsSubscriber = model.Tags.IsSubscriber;
            IsVIP = model.Tags.IsVIP;
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
            IsModerator = model.Tags.IsModerator;
            IsSubscriber = model.Tags.IsSubscriber;
            IsVIP = null;
        }
    }
}
