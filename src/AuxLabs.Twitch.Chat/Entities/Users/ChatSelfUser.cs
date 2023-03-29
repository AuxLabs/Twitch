using System.Collections.Generic;
using Model = AuxLabs.Twitch.Chat.GlobalUserStateTags;

namespace AuxLabs.Twitch.Chat
{
    /// <summary> Global data for the currently authenticated user </summary>
    public class ChatSelfUser : ChatUser
    {
        public IReadOnlyCollection<string> EmoteSets { get; internal set; }

        internal ChatSelfUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal new static ChatSelfUser Create(TwitchChatClient twitch, Model model)
        {
            var entity = new ChatSelfUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);
            EmoteSets = model.EmoteSets;
        }
    }
}
