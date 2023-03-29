using System;
using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;
using ClearMsg = AuxLabs.Twitch.Chat.Models.ClearMessageEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatSimpleMessage : ChatEntity<string>
    {
        public ChatSimpleChannel Channel { get; internal set; }
        public ChatSimpleUser Author { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }
        public string Content { get; internal set; }

        internal ChatSimpleMessage(TwitchChatClient twitch, string id, ChatSimpleChannel channel, ChatSimpleUser author)
            : base(twitch, id)
        {
            Channel = channel;
            Author = author;
        }

        internal static ChatSimpleMessage Create(TwitchChatClient twitch, ClearMsg model, ChatSimpleChannel channel, ChatSimpleUser author)
        {
            var entity = new ChatSimpleMessage(twitch, model.Tags.TargetMessageId, channel, author);
            entity.Update(model);
            return entity;
        }
        internal static ChatSimpleMessage Create(TwitchChatClient twitch, Message model, ChatSimpleChannel channel, ChatSimpleUser author)
        {
            var entity = new ChatSimpleMessage(twitch, model.Tags.MessageId, channel, author);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(ClearMsg model)
        {
            Timestamp = model.Tags.Timestamp;
            Content = model.Message;
        }
        internal virtual void Update(Message model)
        {
            Timestamp = model.Tags.Timestamp;
            Content = model.Message;
        }

        public override string ToString() => Content;
    }
}
