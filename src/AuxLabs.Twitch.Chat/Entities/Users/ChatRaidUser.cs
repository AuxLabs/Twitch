using AuxLabs.Twitch.Chat.Models;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatRaidUser : ChatSimpleUser
    {
        /// <summary>  </summary>
        public string ProfileImageUrl { get; private set; }

        internal ChatRaidUser(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal new static ChatRaidUser Create(TwitchChatClient twitch, RaidTags model)
        {
            var entity = new ChatRaidUser(twitch, model.AuthorId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(RaidTags model)
        {
            base.Update(model);
            ProfileImageUrl = model.ProfileImageUrl;
        }
    }
}
