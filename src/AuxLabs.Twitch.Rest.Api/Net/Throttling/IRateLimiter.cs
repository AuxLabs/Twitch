﻿// https://github.com/discord-net/Wumpus.Net/blob/master/src/Wumpus.Net.Rest/Net/Throttling/IRateLimiter.cs

using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public interface IRateLimiter
    {
        Task EnterLockAsync(string bucketId, CancellationToken cancelToken);
        void UpdateLimit(string bucketId, RateLimitInfo info, bool isRatelimited);
    }
}
