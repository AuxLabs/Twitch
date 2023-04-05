using System.Collections.Generic;

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

        internal static ChatMessage Create(TwitchChatClient twitch, IChatMessage model, ChatSimpleChannel channel, ChatChannelUser author, ChatSimpleUser replyAuthor)
        {
            var entity = new ChatMessage(twitch, model.Id, channel, author);
            entity.Update(model, replyAuthor);
            return entity;
        }
        internal virtual void Update(IChatMessage model, ChatSimpleUser replyAuthor)
        {
            base.Update(model);
            Reply = replyAuthor == null ? null : ChatMessageReply.Create(Twitch, model, replyAuthor);
            Type = model.MessageType;
            BitsAmount = model.BitsAmount;
            Emotes = model.Emotes;
        }
    }
}
