using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Requests;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        public async Task<RestSelfUser> GetMyUserAsync()
        {
            IsUserAuthorized(out var identity);
            MyUser = (await GetUserByIdAsync(identity.UserId)) as RestSelfUser;
            return MyUser;
        }

        public async Task<RestSelfUser> ModifyMyUserAsync(string description)
        {
            var response = await API.PutUserAsync(description);
            return RestSelfUser.Create(this, response.Data.First());
        }

        public async Task<RestUser> GetUserByNameAsync(string username)
            => (await GetUsersByNameAsync(username))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestUser>> GetUsersByNameAsync(params string[] userNames)
        {
            var args = new GetUsersArgs(GetUsersMode.Name, userNames);
            var response = await API.GetUsersAsync(args);
            return response.Data.Select(x => RestUser.Create(this, x)).ToImmutableArray();
        }

        public async Task<RestUser> GetUserByIdAsync(string id)
            => (await GetUsersByIdAsync(id))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestUser>> GetUsersByIdAsync(params string[] userIds)
        {
            var response = await API.GetUsersAsync(new GetUsersArgs
            {
                UserIds = userIds
            });

            return response.Data.Select(x => RestUser.Create(this, x)).ToImmutableArray();
        }

        public async Task<(IReadOnlyCollection<RestFollower> Followers, int Total)> GetFollowersAsync(string broadcasterId, int count = 20)
        {
            var response = await API.GetFollowersAsync(new GetFollowersArgs
            {
                BroadcasterId = broadcasterId,
                First = count
            });
            var data = response.Data.Select(x => RestFollower.Create(this, x)).ToImmutableArray();
            return (data, response.Total.Value);
        }

        public async Task<RestFollower> GetFollowerAsync(string broadcasterId, string userId)
        {
            var response = await API.GetFollowersAsync(new GetFollowersArgs
            {
                BroadcasterId = broadcasterId,
                UserId = userId
            });
            return response?.Data == null || response.Data.Count == 0
                ? null 
                : RestFollower.Create(this, response.Data.First());
        }

        public async Task<(IReadOnlyCollection<RestFollowedChannel> Channels, int Total)> GetFollowedChannelsAsync(int count = 20)
        {
            var response = await API.GetFollowedChannelsAsync(new GetFollowedChannelsArgs
            {
                UserId = MyUser.Id,
                First = count
            });
            var data = response.Data.Select(x => RestFollowedChannel.Create(this, x)).ToImmutableArray();
            return (data, response.Total.Value);
        }

        public async Task<RestFollowedChannel> GetFollowedChannelAsync(string broadcasterId)
        {
            var response = await API.GetFollowedChannelsAsync(new GetFollowedChannelsArgs
            {
                UserId = MyUser.Id,
                BroadcasterId = broadcasterId
            });
            return response?.Data == null || response.Data.Count == 0
                ? null
                : RestFollowedChannel.Create(this, response.Data.First());
        }
    }
}
