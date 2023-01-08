using AuxLabs.SimpleTwitch.Rest.Models;
using AuxLabs.SimpleTwitch.Rest.Net;
using RestEase;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using JsonResponseDeserializer = AuxLabs.SimpleTwitch.Rest.Net.JsonResponseDeserializer;

namespace AuxLabs.SimpleTwitch.Tests
{
    public class MockApiFixture
    {
        public readonly IMockApi _api;
        public readonly AccessToken App;
        public readonly AccessToken User;

        public IEnumerable<User> Users;

        public string ClientId => _api.ClientId;
        public string ClientSecret => _api.ClientSecret;

        public MockApiFixture()
        {
            _api = new RestClient(TestConstants.BaseUrl)
            {
                RequestBodySerializer = new JsonBodySerializer(),
                ResponseDeserializer = new JsonResponseDeserializer()
            }.For<IMockApi>();

            var client = _api.GetClientsAsync().GetAwaiter().GetResult().Data.FirstOrDefault();
            _api.ClientId = client.Id;
            _api.ClientSecret = client.Secret;

            App = _api.GetAppTokenAsync().GetAwaiter().GetResult();
            Users = _api.GetUsersAsync().GetAwaiter().GetResult().Data;
            var fullUser = Users.FirstOrDefault();

            User = _api.GetUserTokenAsync(fullUser.Id, "user:edit").GetAwaiter().GetResult();
        }
    }

    [CollectionDefinition("Mock")]
    public class MockApiCollection : ICollectionFixture<MockApiFixture> { }
}
