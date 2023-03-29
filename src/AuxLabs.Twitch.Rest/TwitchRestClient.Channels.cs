using AuxLabs.Twitch.Rest;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

        public async Task<RestChannel> UpdateMyChannelAsync(PatchChannelBody args)
        {
            IsUserAuthorized(out var identity);
            await API.PatchChannelAsync(new PatchChannelArgs
            {
                BroadcasterId = identity.UserId
            }, args);

            MyChannel.Update(args);
            return MyChannel;
        }

        public async Task<RestChannel> GetChannelAsync(string channelId)
            => (await GetChannelsAsync(channelId)).FirstOrDefault();
        public async Task<IReadOnlyList<RestChannel>> GetChannelsAsync(params string[] channelIds)
        {
            var response = await API.GetChannelsAsync(channelIds);
            return response.Data.Select(x => RestChannel.Create(this, x)).ToImmutableArray();
        }

        public async Task<IReadOnlyCollection<RestEditorUser>> GetChannelEditors(string channelId)
        {
            var response = await API.GetChannelEditorsAsync(channelId);
            return response.Data.Select(x => RestEditorUser.Create(this, x)).ToImmutableArray();
        }

        // Get Followed Channels
        // Get Channel Followers
    }
}
