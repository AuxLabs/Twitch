using AuxLabs.Twitch.Rest.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestTeam : RestPartialTeam
    {
        /// <summary>  </summary>
        public IReadOnlyCollection<RestSimpleUser> Users { get; private set; }

        public RestTeam(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestTeam Create(TwitchRestClient twitch, Team model)
        {
            var entity = new RestTeam(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Team model)
        {
            base.Update(model);
            Users = model.Users.Select(x => RestSimpleUser.Create(Twitch, x)).ToImmutableArray();
        }
    }
}
