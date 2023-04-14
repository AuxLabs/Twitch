using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        public async Task<RestChannel> GetMyChannelAsync()
        {
            IsUserAuthorized(out var identity);
            MyChannel = await GetChannelAsync(identity.UserId);
            return MyChannel;
        }

        public async Task<RestChannel> UpdateMyChannelAsync(Action<PatchChannelBody> func)
        {
            var args = new PatchChannelBody();
            func(args);

            IsUserAuthorized(out var authorized);
            await API.PatchChannelAsync(new PatchChannelArgs
            {
                BroadcasterId = authorized.UserId
            }, args);

            MyChannel.Update(args);
            return MyChannel;
        }

        public async Task<RestChannel> GetChannelAsync(string channelId)
            => (await GetChannelsAsync(channelId))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestChannel>> GetChannelsAsync(params string[] channelIds)
        {
            var response = await API.GetChannelsAsync(channelIds);
            return response.Data.Select(x => RestChannel.Create(this, x)).ToImmutableArray();
        }

        public async Task<IReadOnlyCollection<RestEditor>> GetChannelEditors(string channelId)
        {
            var response = await API.GetChannelEditorsAsync(channelId);
            return response.Data.Select(x => RestEditor.Create(this, x)).ToImmutableArray();
        }

        public async Task<RestFollowUser> GetFollowerAsync(string userId)
        {
            IsUserAuthorized(out var authorized);
            var response = await API.GetFollowersAsync(new GetFollowersArgs
            {
                BroadcasterId = authorized.UserId,
                UserId = userId
            });
            return response?.Data == null || response.Data.Count == 0
                ? null
                : RestFollowUser.Create(this, response.Data.First());
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestFollowUser>> GetFollowersAsync(int count = 20, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var authorized);
            return new PagedAsyncEnumerable<RestFollowUser>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetFollowersAsync(new GetFollowersArgs
                    {
                        BroadcasterId = authorized.UserId,
                        First = count
                    }, cancelToken);
                    return (response.Data.Select(x => RestFollowUser.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }

        public async Task<RestFollowUser> GetFollowedChannelAsync(string broadcasterId)
        {
            IsUserAuthorized(out var authorized);
            var response = await API.GetFollowedChannelsAsync(new GetFollowedChannelsArgs 
            { 
                UserId = authorized.UserId, 
                BroadcasterId = broadcasterId 
            });
            return response?.Data == null || response.Data.Count == 0
                ? null
                : RestFollowUser.Create(this, response.Data.First());
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestFollowUser>> GetFollowedChannelsAsync(int count = 20, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var authorized);
            return new PagedAsyncEnumerable<RestFollowUser>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetFollowedChannelsAsync(new GetFollowedChannelsArgs
                    {
                        UserId = authorized.UserId,
                        First = count,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.Select(x => RestFollowUser.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }
    }
}
