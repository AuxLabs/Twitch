using System.Collections.Generic;
using UserState = AuxLabs.Twitch.Chat.Models.UserStateEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    /// <summary> Data for the currently authenticated user in a specific channel </summary>
    public class ChatChannelSelfUser : ChatChannelUser
    {
        public IReadOnlyCollection<string> EmoteSets { get; internal set; }

        internal ChatChannelSelfUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal static ChatChannelSelfUser Create(TwitchChatClient twitch, string userId, UserState model)
        {
            var entity = new ChatChannelSelfUser(twitch, userId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(UserState model)
        {
            base.Update(model);
            EmoteSets = model.Tags.EmoteSets;
        }
    }
}
