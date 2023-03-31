using AuxLabs.Twitch.Chat.Models;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatWhisperMessage : ChatEntity<string>
    {
        /// <summary>  </summary>
        public ChatUser Author { get; private set; }

        /// <summary>  </summary>
        public string ThreadId { get; private set; }

        /// <summary>  </summary>
        public IReadOnlyCollection<EmotePosition> Emotes { get; private set; }

        /// <summary>  </summary>
        public string Action { get; private set; }

        /// <summary>  </summary>
        public string Content { get; private set; }

        internal ChatWhisperMessage(TwitchChatClient twitch, string id, ChatUser author)
            : base(twitch, id) 
        {
            Author = author;
        }

        internal static ChatWhisperMessage Create(TwitchChatClient twitch, WhisperEventArgs model, ChatUser author)
        {
            var entity = new ChatWhisperMessage(twitch, model.Tags.MessageId, author);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(WhisperEventArgs model)
        {
            ThreadId = model.Tags.ThreadId;
            Emotes = model.Tags.Emotes;
            Action = model.Tags.Action;
            Content = model.Message;
        }
    }
}
