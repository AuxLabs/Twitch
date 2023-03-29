using Model = AuxLabs.Twitch.Chat.MessageEventArgs;

namespace AuxLabs.Twitch.Chat
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

        internal static ChatMessageReply Create(TwitchChatClient twitch, Model model, ChatSimpleUser author)
        {
            var entity = new ChatMessageReply(twitch, model.Tags.ReplyMessageId, author);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Model model)
        {
            Content = model.Tags.ReplyMessageContent;
        }
    }
}
