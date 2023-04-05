namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatMessageReply : ChatEntity<string>
    {
        public ChatSimpleUser Author { get; internal set; }
        public string Content { get; internal set; }

        internal ChatMessageReply(TwitchChatClient twitch, string id, ChatSimpleUser author)
            : base(twitch, id) 
        {
            Author = author;
        }

        internal static ChatMessageReply Create(TwitchChatClient twitch, IChatMessage model, ChatSimpleUser author)
        {
            var entity = new ChatMessageReply(twitch, model.ReplyMessageId, author);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(IChatMessage model)
        {
            Content = model.ReplyMessageContent;
        }
    }
}
