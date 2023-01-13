using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("Mock")]
    public class Channels
    {
        private readonly ITestOutputHelper _output;
        private readonly MockApiFixture _fixture;

        public Channels(ITestOutputHelper output, MockApiFixture fixture)
        {
            _output = output;
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
