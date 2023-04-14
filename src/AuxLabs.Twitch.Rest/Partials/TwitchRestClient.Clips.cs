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
        /// <param name="channelId">
        ///     The channel whose stream you want to create a clip for.
        /// </param>
        /// <param name="delay">
        ///     Whether the API will capture the clip at the moment of the request, or after a short delay.
        /// </param>
        /// <inheritdoc cref="TwitchRestApiClient.PostClipAsync(PostClipArgs, CancellationToken?)"/>
        public async Task<RestSimpleClip> CreateClipAsync(string channelId, bool withDelay = false, CancellationToken? cancelToken = null)
        {
            var response = await API.PostClipAsync(new PostClipArgs
            {
                BroadcasterId = channelId,
                HasDelay = withDelay,
            }, cancelToken);
            return RestSimpleClip.Create(this, response.Data.SingleOrDefault());
        }

        public async Task<RestClip> GetClipAsync(string clipId, CancellationToken? cancelToken = null)
        {
            var response = await API.GetClipsAsync(new GetClipsArgs
            {
                ClipIds = new[] { clipId }
            }, cancelToken);
            return RestClip.Create(this, response.Data.SingleOrDefault());
        }

        public Task<IReadOnlyCollection<RestClip>> GetClipAsync(params string[] clipIds)
            => GetClipsAsync(clipIds);
        public async Task<IReadOnlyCollection<RestClip>> GetClipsAsync(string[] clipIds, CancellationToken? cancelToken = null)
        {
            var response = await API.GetClipsAsync(new GetClipsArgs
            {
                ClipIds = clipIds
            }, cancelToken);
            return response.Data.Select(x => RestClip.Create(this, x)).ToImmutableArray();
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestClip>> GetChannelClipsAsync(string channelId, DateTime? startAt = null, DateTime? endAt = null,
            int count = 20, CancellationToken? cancelToken = null)
        {
            return new PagedAsyncEnumerable<RestClip>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetClipsAsync(new GetClipsArgs
                    {
                        BroadcasterId = channelId,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.Select(x => RestClip.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }

        public IAsyncEnumerable<IReadOnlyCollection<RestClip>> GetGameClipsAsync(string gameId, DateTime? startAt = null, DateTime? endAt = null,
            int count = 20, CancellationToken? cancelToken = null)
        {
            return new PagedAsyncEnumerable<RestClip>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetClipsAsync(new GetClipsArgs
                    {
                        GameId = gameId,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.Select(x => RestClip.Create(this, x)).ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }
    }
}
