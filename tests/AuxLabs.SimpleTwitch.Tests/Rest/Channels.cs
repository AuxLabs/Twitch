using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("mock")]
    public class Channels
    {
        private readonly MockApiFixture _fixture;

        public Channels(MockApiFixture fixture)
        {
            _fixture = fixture;
        }

        // Apparently the mock api doesn have a channels endpoint
        //[Fact]
        public async Task GetChannelAsync()
        {
            var randomChannel = (await _fixture.Mock.GetRandomChannelsAsync(1)).First();
            var channel = await _fixture.Twitch.GetChannelsAsync(randomChannel);

            Assert.NotNull(channel);
            Assert.NotEmpty(channel?.Data);
            Assert.NotNull(channel.Data?.First().BroadcasterId);
            Assert.NotEmpty(channel.Data.First().BroadcasterId);
        }

        //[Fact]
        public async Task GetChannelsAsync()
        {
            var randomChannels = await _fixture.Mock.GetRandomChannelsAsync();
            var channels = await _fixture.Twitch.GetChannelsAsync(randomChannels.ToArray());

            Assert.NotNull(channels);
            Assert.NotEmpty(channels?.Data);
            Assert.NotNull(channels.Data?.First().BroadcasterId);
            Assert.NotEmpty(channels.Data.First().BroadcasterId);
            Assert.Equal(randomChannels.Count(), channels.Data.Count());
        }
    }
}
