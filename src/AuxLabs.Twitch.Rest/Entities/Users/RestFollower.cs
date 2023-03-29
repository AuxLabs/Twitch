﻿using System;
using Model = AuxLabs.Twitch.Rest.Follower;

namespace AuxLabs.Twitch.Rest
{
    public class RestFollower : RestSimpleUser
    {
        /// <summary>  </summary>
        public DateTime FollowedAt { get; private set; }

        internal RestFollower(TwitchRestClient twitch, string id)
            : base(twitch, id) { }
        internal new static RestFollower Create(TwitchRestClient twitch, Model model)
        {
            var entity = new RestFollower(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);
            FollowedAt = model.FollowedAt;
        }
    }
}
