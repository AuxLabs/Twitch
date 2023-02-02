﻿// https://github.com/discord-net/Wumpus.Net/blob/master/src/Wumpus.Net.Rest/Net/Throttling/DefaultRateLimiter.cs

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DefaultRateLimiter : IRateLimiter
    {
        private readonly ConcurrentDictionary<string, RequestBucket> _buckets;
        private DateTimeOffset _globalWaitUntil;

        public DefaultRateLimiter()
        {
            _buckets = new ConcurrentDictionary<string, RequestBucket>();
        }

        public async Task EnterLockAsync(string bucketId, CancellationToken cancelToken)
        {
            await EnterGlobalLockAsync(cancelToken).ConfigureAwait(false);
            //await EnterBucketLockAsync(bucketId, cancelToken).ConfigureAwait(false);
        }

        public virtual async Task EnterGlobalLockAsync(CancellationToken cancelToken)
        {
            while (true)
            {
                int millis = (int)Math.Ceiling((_globalWaitUntil - DateTimeOffset.UtcNow).TotalMilliseconds);
                if (millis <= 0)
                    break;
                else
                    await Task.Delay(millis, cancelToken).ConfigureAwait(false);
            }
        }
        public virtual async Task EnterBucketLockAsync(string bucketId, CancellationToken cancelToken)
        {
            // TODO: We should clean up old buckets
            var bucket = _buckets.GetOrAdd(bucketId, x => new RequestBucket());
            await bucket.EnterAsync(cancelToken);
        }

        public virtual void UpdateLimit(string bucketId, RateLimitInfo info)
        {
            if (info.IsGlobal)
                _globalWaitUntil = info.Reset.Value.AddMilliseconds(info.Lag?.TotalMilliseconds ?? 0.0);
            else
            {
                var bucket = _buckets.GetOrAdd(bucketId, x => new RequestBucket());
                bucket.UpdateRateLimit(info);
            }
        }
    }
}
