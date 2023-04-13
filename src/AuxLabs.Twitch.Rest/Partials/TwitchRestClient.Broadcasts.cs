using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Requests;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public partial class TwitchRestClient
    {
        public async Task<string> GetStreamKeyAsync()
        {
            IsUserAuthorized(out var authorized);
            var response = await API.GetBroadcastKeyAsync(new GetBroadcastKeyArgs
            {
                BroadcasterId = authorized.UserId
            });

            return response.Data.SingleOrDefault();
        }

        public async Task<RestBroadcast> GetBroadcastByIdAsync(string channelId)
            => (await GetBroadcastsByIdAsync(channelId))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestBroadcast>> GetBroadcastsByIdAsync(params string[] channelIds)
        {
            var response = await API.GetBroadcastsAsync(new GetBroadcastsArgs
            {
                UserIds = channelIds
            });
            return response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray();
        }

        public async Task<RestBroadcast> GetBroadcastByNameAsync(string channelName)
            => (await GetBroadcastsByNameAsync(channelName))?.SingleOrDefault();
        public async Task<IReadOnlyCollection<RestBroadcast>> GetBroadcastsByNameAsync(params string[] channelNames)
        {
            var response = await API.GetBroadcastsAsync(new GetBroadcastsArgs
            {
                UserNames = channelNames
            });
            return response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray();
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestBroadcast>> GetBroadcastsAsync(string[] userNames = null, string[] userIds = null, string[] gameIds = null, string[] languages = null,
            int count = 20, CancellationToken? cancelToken = null)
        {
            return new PagedAsyncEnumerable<RestBroadcast>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetBroadcastsAsync(new GetBroadcastsArgs
                    {
                        UserNames = userNames,
                        UserIds = userIds,
                        GameIds = gameIds,
                        Languages = languages,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                nextPage: (info, amount, cursor) =>
                {
                    if (amount != TwitchConstants.DefaultMaxPerPage)
                        return false;
                    info.Cursor = cursor;
                    return true;
                },
                count: count);
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestBroadcast>> GetFollowedBroadcastsAsync(int count = 20, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var authorized);
            return new PagedAsyncEnumerable<RestBroadcast>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetFollowedBroadcastsAsync(new GetFollowedBroadcastsArgs
                    {
                        UserId = authorized.UserId,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                nextPage: (info, amount, cursor) =>
                {
                    if (amount != TwitchConstants.DefaultMaxPerPage)
                        return false;
                    info.Cursor = cursor;
                    return true;
                },
                count: count);
        }

        public async Task<RestMarker> CreateMarkerAsync(string description = null, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var authorized);
            var response = await API.PostBroadcastMarkerAsync(new PostBroadcastMarkerBody
            {
                UserId = authorized.UserId,
                Description = description
            }, cancelToken);
            return RestMarker.Create(this, response.Data.SingleOrDefault());
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestMarker>> GetMarkersAsync(string channelId, string videoId,
            int count = 20, CancellationToken? cancelToken = null)
        {
            IsUserAuthorized(out var authorized);
            return new PagedAsyncEnumerable<RestMarker>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetBroadcastMarkersAsync(new GetBroadcastMarkersArgs
                    {
                        UserId = channelId,
                        VideoId = videoId,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.Select(x => RestMarker.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                nextPage: (info, amount, cursor) =>
                {
                    if (amount != TwitchConstants.DefaultMaxPerPage)
                        return false;
                    info.Cursor = cursor;
                    return true;
                },
                count: count);
        }
    }
}
