using AuxLabs.SimpleTwitch.Rest;
using AuxLabs.SimpleTwitch.Rest.Requests;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("Mock")]
    public class Authentication
    {
        private readonly ITestOutputHelper _output;
        private readonly MockApiFixture _fixture;

        public Authentication(ITestOutputHelper output, MockApiFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public async Task SuccessfulLoginAsync()
        {
            var twitch = new TwitchRestApiClient(TestConstants.MockApiUrl)
            {
                Authorization = new AuthenticationHeaderValue("Bearer", _fixture.User.Token),
                ClientId = _fixture.ClientId
            };

            var self = await twitch.GetUsersAsync(new GetUsersParams
            {
                UserNames = new[] { _fixture.Users.First().Login }
            });

            Assert.NotNull(self);
            Assert.NotEmpty(self?.Data);
            Assert.NotEmpty(self?.Data?.First().Id);
        }
    }
}
