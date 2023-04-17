using AuxLabs.Twitch.Rest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestChannelTeam : RestPartialTeam
    {
        /// <summary>  </summary>
        public RestSimpleUser Broadcaster { get; private set; }

        public RestChannelTeam(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestChannelTeam Create(TwitchRestClient twitch, ChannelTeam model)
        {
            var entity = new RestChannelTeam(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(ChannelTeam model)
        {
            base.Update(model);
            Broadcaster = RestSimpleUser.Create(Twitch, model);
        }
    }
}
