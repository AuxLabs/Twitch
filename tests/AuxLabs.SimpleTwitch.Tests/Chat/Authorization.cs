using AuxLabs.SimpleTwitch.Chat;
using AuxLabs.SimpleTwitch.Chat.Requests;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AuxLabs.SimpleTwitch.Tests.Chat
{
    public class Authorization
    {
        private readonly TwitchChatApiClient _twitch;

        public Authorization()
        {
            _twitch = new TwitchChatApiClient(new TwitchChatConfig
            {
                RequestCommands = true,
                RequestMembership = true,
                RequestTags = true
            });

            _twitch.Connected += OnConnectedAsync;
        }

        [Fact]
        public async Task ConnectAsync()
        {
            await _twitch.RunAsync();
        }

        private void OnConnectedAsync()
        {
            _twitch.SendIdentify("auxlabs", "");
            _twitch.Send(new JoinChannelRequest("auxlabs"));
        }
    }
}
