using AuxLabs.SimpleTwitch.Chat;
using AuxLabs.SimpleTwitch.Chat.Requests;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AuxLabs.SimpleTwitch.Tests.Chat
{
    public class Authorization
    {
        private readonly TwitchChatApiClient _twitch;
        private readonly ITestOutputHelper _output;

        public Authorization(ITestOutputHelper output)
        {
            _output = output;
        }

        public Authorization()
        {
            _twitch = new TwitchChatApiClient(new TwitchChatConfig
            {
                RequestCommands = true,
                RequestMembership = true,
                RequestTags = true
            });

            _twitch.Connected += OnConnectedAsync;
            _twitch.SentPayload += OnPayloadSent;
        }

        [Fact]
        public void ConnectAsync()
        {
            _twitch.Run();
        }

        private void OnConnectedAsync()
        {
            _twitch.SendIdentify("auxlabs", "");
            _twitch.Send(new JoinChannelRequest("auxlabs"));
        }

        private void OnPayloadSent(IrcPayload msg, int size)
        {
            _output.WriteLine(msg.ToString());
        }
    }
}
