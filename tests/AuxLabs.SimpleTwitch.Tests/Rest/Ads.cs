using AuxLabs.SimpleTwitch.Rest;
using System.Threading.Tasks;
using Xunit;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("mock")]
    public class Ads
    {
        private readonly MockApiFixture _fixture;

        public Ads(MockApiFixture fixture)
        {
            _fixture = fixture;
        }

        private async Task StartCommercialAsync()
        {
            var response = await _fixture.Twitch.PostCommercialAsync(new PostChannelCommercialParams
            {
                BroadcasterId = _fixture.AuthorizedUser.Id,
                Length = 30
            });

            Assert.NotNull(response);
            Assert.NotNull(response?.Data);
        }
    }
}
