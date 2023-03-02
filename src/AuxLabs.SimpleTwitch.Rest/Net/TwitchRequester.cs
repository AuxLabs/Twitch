// https://github.com/discord-net/Wumpus.Net/blob/master/src/Wumpus.Net.Rest/Net/WumpusRequester.cs

using RestEase;
using RestEase.Implementation;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class TwitchRequester : Requester
    {
        private readonly IRateLimiter _rateLimiter;

        public TwitchRequester(HttpClient httpClient, IRateLimiter rateLimiter)
            : base(httpClient)
        {
            _rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            ResponseDeserializer = new JsonResponseDeserializer();
            RequestBodySerializer = new JsonBodySerializer();
            RequestQueryParamSerializer = new JsonQueryParamSerializer();
        }

        protected override async Task<HttpResponseMessage> SendRequestAsync(IRequestInfo request, bool readBody)
        {
            var bucketId = GenerateBucketId(request);
            while (true)
            {
                await _rateLimiter.EnterLockAsync(bucketId, request.CancellationToken).ConfigureAwait(false);

                bool allowAnyStatus = request.AllowAnyStatusCode;
                ((RequestInfo)request).AllowAnyStatusCode = true;
                var response = await base.SendRequestAsync(request, readBody).ConfigureAwait(false);

                var info = new RateLimitInfo(response.Headers, request.BasePath, bucketId);
                if (response.IsSuccessStatusCode)
                {
                    _rateLimiter.UpdateLimit(bucketId, info, false);
                    return response;
                }

                switch (response.StatusCode)
                {
                    case (HttpStatusCode)429:
                        _rateLimiter.UpdateLimit(bucketId, info, true);
                        continue;
                    case HttpStatusCode.BadGateway: //502
                        await Task.Delay(250, request.CancellationToken).ConfigureAwait(false);
                        continue;
                    default:
                        if (allowAnyStatus)
                            return response;

                        var bytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                        if (bytes.Length > 0)
                        {
                            RestError error = null;
                            try { error = JsonSerializer.Deserialize<RestError>(bytes.AsSpan()); } catch { }
                            if (error != null)
                                throw new TwitchRestException(response.StatusCode, error.Code, error.Message);

                            string msg = null;
                            try { msg = Encoding.UTF8.GetString(bytes); } catch { }
                            if (msg != null)
                                throw new TwitchRestException(response.StatusCode, null, msg);
                        }
                        throw new TwitchRestException(response.StatusCode);
                }
            }
        }

        private string GenerateBucketId(IRequestInfo request)
        {
            var bucketId = $"{request.Method.Method} {request.Path}";
            switch (bucketId)       // Some of these need unique buckets based on parameters
            {
                case "POST chat/shoutouts":             // 1 per 2 minutes, broadcaster per 60 minutes
                case "GET extensions/configurations":   // 20 per 1 minute
                case "PUT extensions/configurations":   // 20 per 1 minute
                case "POST extensions/pubsub":          // 100 per minute per client id and broadcaster tuple
                case "POST extensions/chat":            // 12 per minute per channel
                case "POST moderation/enforcements/status": // Normal: 5 per minute, 50 per hour
                                                            // Affiliate: 10 per minute, 100 per hour
                                                            // Partner: 30 per minute, 300 per hour
                case "POST moderation/moderators":      // 10 per 10 seconds
                case "DELETE moderation/moderators":    // 10 per 10 seconds
                case "POST channels/vips":              // 10 per 10 seconds
                case "DELETE channels/vips":            // 10 per 10 seconds
                case "POST raids":                      // 10 per 10 seconds
                case "DELETE raids":                    // 10 per 10 seconds
                case "POST whispers":                   // 40 users per 24 hours, 3 per second, 100 per minute
                    return bucketId;
                default:                                // Global by header values
                    return TwitchConstants.GlobalRatelimitBucket;
            }
        }
    }
}
