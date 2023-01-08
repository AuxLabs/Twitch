using AuxLabs.SimpleTwitch.Rest.Requests;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("Mock")]
    public class Ads
    {
        private readonly ITestOutputHelper _output;
        private readonly MockApiFixture _fixture;

        public Ads(ITestOutputHelper output, MockApiFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public async Task StartCommercialAsync()
        {
            var response = await _fixture.Twitch.PostCommercialAsync(new PostChannelCommercialParams
            {
                BroadcasterId = _fixture.AuthorizedUser.Id,
                Length = 30
            });

            Assert.NotNull(response);
            Assert.NotNull(response?.Data);
            _output.WriteLine($"Requested length of 30, got {response.Data.First().Length}");
        }
    }
}
