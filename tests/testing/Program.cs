using AuxLabs.Twitch.Chat.Api;
using AuxLabs.Twitch.Rest.Api;

var rest = new TwitchRestApiClient();

var token = Environment.GetEnvironmentVariable("TWITCH_TOKEN", EnvironmentVariableTarget.User);
var identity = await rest.ValidateAsync(token);

var chat = new TwitchChatApiClient()
    .WithIdentity(identity.UserName, token);

Console.WriteLine("> Connecting...");

chat.Connected += OnConnected;
chat.UserNoticeReceived += args => Console.WriteLine($"{args.Tags.GetType().Name}: {args.Message}");
chat.MessageReceived += args => Console.WriteLine($"#{args.ChannelName} {args.UserName}: {args.Message}");
chat.ChannelJoined += args => Console.WriteLine($"> Joined #{args.ChannelName}");

await chat.RunAsync();

void OnConnected()
{
    Console.WriteLine("> Connected");
    chat.SendJoinAsync("spaceyeen");
}