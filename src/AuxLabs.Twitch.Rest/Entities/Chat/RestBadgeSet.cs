using AuxLabs.Twitch.Rest.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestBadgeSet : RestEntity<string>
    {
        /// <summary>  </summary>
        public IReadOnlyCollection<RestBadge> Versions { get; private set; }

        internal RestBadgeSet(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestBadgeSet Create(TwitchRestClient twitch, BadgeSet model)
        {
            var entity = new RestBadgeSet(twitch, model.SetId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(BadgeSet model)
        {
            Versions = model.Versions.Select(x => RestBadge.Create(Twitch, x)).ToImmutableArray();
        }
    }
}
