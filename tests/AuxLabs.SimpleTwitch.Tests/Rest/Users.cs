using AuxLabs.SimpleTwitch.Rest;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    [Collection("mock")]
    public class Users
    {
        private readonly MockApiFixture _fixture;

        public Users(MockApiFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetUsersByNameAsync()
        {
            var randomUsers = await _fixture.Mock.GetRandomUsernamesAsync();
            var users = await _fixture.Twitch.GetUsersAsync(new GetUsersArgs
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
            var users = await _fixture.Twitch.GetUsersAsync(new GetUsersArgs
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
