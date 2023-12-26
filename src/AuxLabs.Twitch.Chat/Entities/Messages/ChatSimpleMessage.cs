using System;
using ClearMsg = AuxLabs.Twitch.Chat.Models.ClearMessageEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatSimpleMessage : ChatEntity<string>
    {
        public ChatSimpleChannel Channel { get; internal set; }
        public ChatSimpleUser Author { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }
        public string Content { get; internal set; }
        public bool ContainsSpecialCharacters { get; private set; }

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

        internal virtual void Update(ClearMsg model)
        {
            Timestamp = model.Tags.Timestamp;
            Content = model.Message;
        }
        internal virtual void Update(IChatMessage model)
        {
            Timestamp = model.Timestamp;
            Content = model.Content;
        }

        public override string ToString() => Content;
    }
}
