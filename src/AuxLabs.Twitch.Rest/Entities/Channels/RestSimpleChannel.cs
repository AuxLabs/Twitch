using AuxLabs.Twitch;
using AuxLabs.Twitch.Rest;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public class RestSimpleChannel : RestEntity<string>, IChannel
    {
        /// <summary> The broadcaster’s display name. </summary>
        public string DisplayName { get; private set; }

        /// <summary> The broadcaster’s login name. </summary>
        public string Name { get; private set; }

        internal RestSimpleChannel(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestSimpleChannel Create(TwitchRestClient twitch, Channel model)
        {
            var entity = new RestSimpleChannel(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Channel model)
        {
            this.DisplayName = model.BroadcasterDisplayName;
            this.Name = model.BroadcasterName;
        }

        internal static RestSimpleChannel Create(TwitchRestClient twitch, FollowedChannel model)
        {
            var entity = new RestSimpleChannel(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(FollowedChannel model)
        {
            this.DisplayName = model.BroadcasterDisplayName;
            this.Name = model.BroadcasterName;
        }

        /// <summary> Get the user associated with this channel. </summary>
        public Task<RestUser> GetUserAsync()
            => Twitch.GetUserByIdAsync(Id);
    }
}
