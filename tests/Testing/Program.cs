
using AuxLabs.SimpleTwitch;
using AuxLabs.SimpleTwitch.Chat;
using AuxLabs.SimpleTwitch.Chat.Models;
using AuxLabs.SimpleTwitch.Chat.Requests;

var twitch = new TwitchChatApiClient(new TwitchChatConfig
{
    RequestCommands = true,
    RequestMembership = true,
    RequestTags = true
});

twitch.Connected += OnConnectedAsync;
twitch.SentPayload += OnPayloadSent;
twitch.ReceivedPayload += OnPayloadReceived;

twitch.MessageReceived += OnMessageReceived;

await twitch.RunAsync();

void OnConnectedAsync()
{
    Console.WriteLine("Connected");

    twitch.SendIdentify("auxlabs", "");
    twitch.Send(new JoinChannelRequest("auxlabs"));
}

void OnPayloadSent(IrcMessage msg, int size)
{
    Console.WriteLine("-> " + msg.ToString());
}

void OnPayloadReceived(IrcMessage msg, long size)
{
    var ignoreEvents = new[] { IrcCommand.Message, IrcCommand.GlobalUserState };
    if (ignoreEvents.Any(x => x == msg.Command)) return;

    Console.WriteLine("<- " + msg.ToString());
}

void OnMessageReceived(MessageEventArgs args)
{
    var name = !string.IsNullOrEmpty(args.Tags.DisplayName) ? args.Tags.DisplayName : args.UserName;

    if (args.Tags.Emotes != null)
    {
        Console.WriteLine();
    }

    if (!string.IsNullOrWhiteSpace(args.Tags.ReplyParentMessageId))
        Console.WriteLine($"#{args.ChannelName} {name} -> {args.Tags.ReplyParentUserLogin}: {args.Message}");
    else
        Console.WriteLine($"#{args.ChannelName} {name}: {args.Message}");
}
