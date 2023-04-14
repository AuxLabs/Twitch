using AuxLabs.Twitch.Rest.Entities;
using AuxLabs.Twitch.Rest.Models;
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
        public async Task<ExtensionAnalytic> GetExtensionAnalyticAsync(string extensionId, DateTime? startAt = null, DateTime? endAt = null, CancellationToken? cancelToken = null)
        {
            var response = await API.GetExtensionAnalyticsAsync(new GetExtensionAnalyticsArgs
            {
                ExtensionId = extensionId,
                StartedAt = startAt,
                EndedAt = endAt
            }, cancelToken: cancelToken);
            return response.Data.SingleOrDefault();
        }
        public IAsyncEnumerable<IReadOnlyCollection<ExtensionAnalytic>> GetExtensionAnalyticsAsync(string extensionId = null, DateTime? startAt = null, DateTime? endAt = null,
            int count = 20, CancellationToken? cancelToken = null)
        {
            return new PagedAsyncEnumerable<ExtensionAnalytic>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetExtensionAnalyticsAsync(new GetExtensionAnalyticsArgs
                    {
                        ExtensionId = extensionId,
                        StartedAt = startAt,
                        EndedAt = endAt,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }

        public async Task<GameAnalytic> GetGameAnalyticAsync(string gameId, DateTime? startAt = null, DateTime? endAt = null, CancellationToken? cancelToken = null)
        {
            var response = await API.GetGameAnalyticsAsync(new GetGameAnalyticsArgs
            {
                GameId = gameId,
                StartedAt = startAt,
                EndedAt = endAt
            }, cancelToken: cancelToken);
            return response.Data.SingleOrDefault();
        }
        public IAsyncEnumerable<IReadOnlyCollection<GameAnalytic>> GetGameAnalyticsAsync(string gameId = null, DateTime? startAt = null, DateTime? endAt = null,
            int count = 20, CancellationToken? cancelToken = null)
        {
            return new PagedAsyncEnumerable<GameAnalytic>(
                TwitchConstants.DefaultMaxPerPage,
                async (info, ct) =>
                {
                    var response = await API.GetGameAnalyticsAsync(new GetGameAnalyticsArgs
                    {
                        GameId = gameId,
                        StartedAt = startAt,
                        EndedAt = endAt,
                        First = info.PageSize,
                        After = info.Cursor
                    }, cancelToken);
                    return (response.Data.ToImmutableArray(), response.Pagination.Value.Cursor);
                },
                count: count);
        }

        public async Task<IReadOnlyCollection<RestBitsUser>> GetBitsLeaderboardAsync(string userId = null, DateTime? startAt = null, BitsPeriod? bitsPeriod = null,
            int count = 10, CancellationToken? cancelToken = null)
        {
            var response = await API.GetBitsLeaderboardAsync(new GetBitsLeaderboardArgs
            {
                UserId = userId,
                StartedAt = startAt,
                Period = bitsPeriod,
                Count = count,
            }, cancelToken);
            return response.Data.Select(x => RestBitsUser.Create(this, x)).ToImmutableArray();
        }
    }
}
