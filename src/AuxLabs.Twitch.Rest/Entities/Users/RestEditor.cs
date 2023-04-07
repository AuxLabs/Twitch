using AuxLabs.Twitch.Rest.Models;
using System;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestEditor : RestPartialUser
    {
        /// <summary>  </summary>
        public DateTime CreatedAt { get; private set; }

        public RestEditor(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestEditor Create(TwitchRestClient twitch, ChannelEditor model)
        {
            var entity = new RestEditor(twitch, model.UserId);
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
