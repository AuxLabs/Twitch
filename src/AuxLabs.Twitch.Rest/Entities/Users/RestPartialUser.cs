using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public class RestPartialUser : RestEntity<string>
    {
        /// <summary> User’s login name </summary>
        public string Name { get; private set; }

        public RestPartialUser(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestPartialUser Create(TwitchRestClient twitch, string id, string name)
        {
            var entity = new RestPartialUser(twitch, id);
            entity.Update(name);
            return entity;
        }
        internal virtual void Update(string name)
        {
            Name = name;
        }

        public override string ToString() => Name + $"({Id})";

        /// <summary> Get the channel associated with this user. </summary>
        public Task<RestChannel> GetChannelAsync()
            => Twitch.GetChannelAsync(Id);

        /// <summary> Get the broadcast associated with this user. </summary>
        /// <returns> A <see cref="RestBroadcast"/> object or null if the user is not currently streaming. </returns>
        public Task<RestBroadcast> GetBroadcastAsync()
            => Twitch.GetBroadcastByIdAsync(Id);

        public Task<RestFollower> GetFollowerAsync(string userId)
            => Twitch.GetFollowerAsync(userId, Id);
        public Task<(IReadOnlyList<RestFollower> Followers, int Total)> GetFollowersAsync(int count = 20)
            => Twitch.GetFollowersAsync(Id, count);
        public Task<(IReadOnlyList<RestFollowedChannel> Channels, int Total)> GetFollowedChannelsAsync(int count = 20)
            => Twitch.GetFollowedChannelsAsync(count);
        public Task<RestFollowedChannel> GetFollowedChannelAsync(string broadcasterId)
            => Twitch.GetFollowedChannelAsync(broadcasterId);
    }
}
