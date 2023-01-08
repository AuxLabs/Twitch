using AuxLabs.SimpleTwitch.Rest;
using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Net;
using AuxLabs.SimpleTwitch.Rest.Requests;
using RestEase;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using JsonResponseDeserializer = AuxLabs.SimpleTwitch.Rest.Net.JsonResponseDeserializer;

namespace AuxLabs.SimpleTwitch.Tests
{
    public class MockApiFixture
    {
        public readonly TwitchRestApiClient Twitch;
        public readonly IMockApi Mock;
        public readonly AccessToken App;
        public readonly AccessToken User;

        public User AuthorizedUser;

        public MockApiFixture()
        {
            Mock = new RestClient(TestConstants.BaseUrl)
            {
                RequestBodySerializer = new JsonBodySerializer(),
                ResponseDeserializer = new JsonResponseDeserializer()
            }.For<IMockApi>();

            var client = Mock.GetClientsAsync().GetAwaiter().GetResult().Data.FirstOrDefault();
            Mock.ClientId = client.Id;
            Mock.ClientSecret = client.Secret;

            App = Mock.GetAppTokenAsync().GetAwaiter().GetResult();
            AuthorizedUser = Mock.GetUsersAsync().GetAwaiter().GetResult().Data.FirstOrDefault();

            User = Mock.GetUserTokenAsync(AuthorizedUser.Id, "user:edit").GetAwaiter().GetResult();

            Twitch = new TwitchRestApiClient(TestConstants.MockApiUrl)
            {
                Authorization = new AuthenticationHeaderValue("Bearer", User.Token),
                ClientId = Mock.ClientId
            };
        }

        [Fact]
        public async Task ConfirmAuthenticationAsync()
        {
            var self = await Twitch.GetUsersAsync(new GetUsersParams
            {
                UserIds = new[] { AuthorizedUser.Id }
            });

            Assert.NotNull(self);
            Assert.NotEmpty(self?.Data);
            Assert.NotEmpty(self?.Data?.First().Id);
        }
    }

    [CollectionDefinition("Mock")]
    public class MockApiCollection : ICollectionFixture<MockApiFixture> { }
}
