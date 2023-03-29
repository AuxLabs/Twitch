using System.Collections.Generic;
using Message = AuxLabs.Twitch.Chat.Models.MessageEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatMessage : ChatSimpleMessage
    {
        public ChatMessageReply Reply { get; internal set; }
        public MessageType Type { get; internal set; }
        public int BitsAmount { get; internal set; }
        public IReadOnlyCollection<EmotePosition> Emotes { get; internal set; }

        internal ChatMessage(TwitchChatClient twitch, string id, ChatSimpleChannel channel, ChatChannelUser author)
            : base(twitch, id, channel, author) { }

        internal static ChatMessage Create(TwitchChatClient twitch, Message model, ChatSimpleChannel channel, ChatChannelUser author, ChatSimpleUser replyAuthor)
        {
            var entity = new ChatMessage(twitch, model.Tags.MessageId, channel, author);
            entity.Update(model, replyAuthor);
            return entity;
        }
        internal virtual void Update(Message model, ChatSimpleUser replyAuthor)
        {
            base.Update(model);
            Reply = replyAuthor == null ? null : ChatMessageReply.Create(Twitch, model, replyAuthor);
            Type = model.Tags.MessageType;
            BitsAmount = model.Tags.BitsAmount;
            Emotes = model.Tags.Emotes;
        }
    }
}
