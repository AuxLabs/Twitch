using AuxLabs.SimpleTwitch.Rest;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("Mock")]
    public class Users
    {
        private readonly ITestOutputHelper _output;
        private readonly MockApiFixture _fixture;

        public Users(ITestOutputHelper output, MockApiFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public async Task GetUsersByNameAsync()
        {
            var randomUsers = await _fixture.Mock.GetRandomUsernamesAsync();
            var users = await _fixture.Twitch.GetUsersAsync(new GetUsersParams
            {
                UserNames = randomUsers
            });

            Assert.NotNull(users);
            Assert.NotEmpty(users?.Data);
            Assert.NotNull(users.Data?.First().Id);
            Assert.NotEmpty(users.Data.First().Id);
            Assert.Equal(randomUsers.Count(), users.Data.Count());
        }

        [Fact]
        public async Task GetUsersByIdAsync()
        {
            var randomUsers = await _fixture.Mock.GetRandomUserIdsAsync();
            var users = await _fixture.Twitch.GetUsersAsync(new GetUsersParams
            {
                UserIds = randomUsers
            });

            Assert.NotNull(users);
            Assert.NotEmpty(users?.Data);
            Assert.NotNull(users.Data?.First().Id);
            Assert.NotEmpty(users.Data.First().Id);
            Assert.Equal(randomUsers.Count(), users.Data.Count());
        }

        [Fact]
        public Task PaginateUsersAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public Task ModifyUserAsync()
        {
            return Task.CompletedTask;
        }
    }
}
