using AuxLabs.Twitch.Rest;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

            return response.Data.FirstOrDefault();
        }

        public async Task<RestBroadcast> GetBroadcastByIdAsync(string channelId)
            => (await GetBroadcastsByIdAsync(channelId))?.FirstOrDefault();
        public async Task<IReadOnlyCollection<RestBroadcast>> GetBroadcastsByIdAsync(params string[] channelIds)
        {
            var response = await API.GetBroadcastsAsync(new GetBroadcastsArgs
            {
                UserIds = channelIds
            });
            return response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray();
        }

        public async Task<RestBroadcast> GetBroadcastByNameAsync(string channelName)
            => (await GetBroadcastsByNameAsync(channelName))?.FirstOrDefault();
        public async Task<IReadOnlyCollection<RestBroadcast>> GetBroadcastsByNameAsync(params string[] channelNames)
        {
            var response = await API.GetBroadcastsAsync(new GetBroadcastsArgs
            {
                UserNames = channelNames
            });
            return response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray();
        }

        public async Task<IReadOnlyCollection<RestBroadcast>> GetBroadcastsAsync(GetBroadcastsArgs args)
        {
            var response = await API.GetBroadcastsAsync(args);
            return response.Data.Select(x => RestBroadcast.Create(this, x)).ToImmutableArray();
        }
    }
}
