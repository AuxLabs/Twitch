using AuxLabs.SimpleTwitch.Rest;
using AuxLabs.SimpleTwitch.Rest.Requests;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AuxLabs.SimpleTwitch.Tests.Rest
{
    public class Authentication
    {
        private readonly ITestOutputHelper _output;
        private readonly IConfiguration _config;

        public Authentication(ITestOutputHelper output)
        {
            _output = output;
            _config = new ConfigurationBuilder()
                .AddJsonFile("./_config.json")
                .Build();
        }

        [Fact]
        public async Task SuccessfulLoginAsync()
        {
            var twitch = new TwitchRestApiClient()
            {
                Authorization = new AuthenticationHeaderValue("Bearer", _config["twitch:token"]),
                ClientId = _config["twitch:client_id"]!
            };

            var self = await twitch.GetUsersAsync(new GetUsersParams
            {
                UserNames = new[] { "auxlabs" }
            });

            Assert.NotNull(self);
            Assert.NotEmpty(self?.Data);
            Assert.NotEmpty(self?.Data?.First().Id);
        }
    }
}
