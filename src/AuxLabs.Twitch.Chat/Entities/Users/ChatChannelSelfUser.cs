using System.Collections.Generic;
using Model = AuxLabs.Twitch.Chat.UserStateEventArgs;

namespace AuxLabs.Twitch.Chat
{
    /// <summary> Data for the currently authenticated user in a specific channel </summary>
    public class ChatChannelSelfUser : ChatChannelUser
    {
        public IReadOnlyCollection<string> EmoteSets { get; internal set; }

        internal ChatChannelSelfUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal new static ChatChannelSelfUser Create(TwitchChatClient twitch, Model model)
        {
            var entity = new ChatChannelSelfUser(twitch, model.Tags.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);
            EmoteSets = model.Tags.EmoteSets;
        }
    }
}
