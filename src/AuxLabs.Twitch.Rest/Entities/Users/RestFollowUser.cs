using AuxLabs.Twitch.Rest.Models;
using System;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestFollowUser : RestSimpleUser
    {
        /// <summary>  </summary>
        public DateTime FollowedAt { get; private set; }

        internal RestFollowUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestFollowUser Create(TwitchRestClient twitch, Follower model)
        {
            var entity = new RestFollowUser(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Follower model)
        {
            base.Update(model);
            FollowedAt = model.FollowedAt;
        }

        internal static RestFollowUser Create(TwitchRestClient twitch, FollowedChannel model)
        {
            var entity = new RestFollowUser(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(FollowedChannel model)
        {
            base.Update(model);
            FollowedAt = model.FollowedAt;
        }
    }
}
