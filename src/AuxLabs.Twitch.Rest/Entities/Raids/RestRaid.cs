using AuxLabs.Twitch.Rest.Models;
using System;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestRaid
    {
        /// <summary>  </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>  </summary>
        public bool IsMature { get; private set; }

        internal RestRaid() { }
        internal static RestRaid Create(TwitchRestClient twitch, Raid model)
        {
            var entity = new RestRaid();
            entity.Update(twitch, model);
            return entity;
        }
        internal virtual void Update(TwitchRestClient twitch, Raid model)
        {
            CreatedAt = model.CreatedAt;
            IsMature = model.IsMature;
        }
    }
}
