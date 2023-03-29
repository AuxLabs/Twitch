using AuxLabs.Twitch.Rest;
using System;

namespace AuxLabs.Twitch.Rest
{
    public class RestEditorUser : RestPartialUser
    {
        /// <summary>  </summary>
        public DateTime CreatedAt { get; private set; }

        public RestEditorUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestEditorUser Create(TwitchRestClient twitch, ChannelEditor model)
        {
            var entity = new RestEditorUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(ChannelEditor model)
        {
            base.Update(model.UserName);
            CreatedAt = model.CreatedAt;
        }
    }
}
