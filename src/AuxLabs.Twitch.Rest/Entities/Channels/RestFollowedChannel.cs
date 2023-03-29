using AuxLabs.Twitch.Rest;
using System;

namespace AuxLabs.Twitch.Rest
{
    public class RestFollowedChannel : RestSimpleChannel
    {
        /// <summary>  </summary>
        public DateTime FollowedAt { get; set; }

        internal RestFollowedChannel(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal new static RestFollowedChannel Create(TwitchRestClient twitch, FollowedChannel model)
        {
            var entity = new RestFollowedChannel(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(FollowedChannel model)
        {
            base.Update(model);
            this.FollowedAt = model.FollowedAt;
        }
    }
}
