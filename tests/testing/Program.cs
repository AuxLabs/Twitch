using AuxLabs.Twitch;
using AuxLabs.Twitch.Rest;

var twitch = new TwitchRestClient();

var token = Environment.GetEnvironmentVariable("TWITCH_TOKEN", EnvironmentVariableTarget.User);
var identity = await twitch.ValidateAsync(token);

var user = await twitch.GetUserByNameAsync("canadian_dragon");
var videos = await twitch.GetVideosByUserAsync(user.Id, count: 150).FlattenAsync();

foreach (var video in videos)
    Console.WriteLine($"{video.User}| {video.Title}\t{video.Description}");

await Task.Delay(1000);

//using AuxLabs.Twitch;
//using AuxLabs.Twitch.Chat;
//using AuxLabs.Twitch.Chat.Entities;

//int msgTotal = 0;
//var timer = new Timer(OnTimer, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1));

//var token = Environment.GetEnvironmentVariable("TWITCH_TOKEN", EnvironmentVariableTarget.User);

//var chat = new TwitchChatClient();
//await chat.ValidateAsync(token);

//chat.Connected += OnConnectedAsync;
//chat.MessageReceived += OnMessageAsync;

//await chat.RunAsync();
//await Task.Delay(-1);

//async Task OnConnectedAsync()
//{
//    Console.WriteLine("> Connected");

//    var top = (await chat.Rest.GetBroadcastsAsync(count: 1000).FlattenAsync()).ToList();
//    int total = top.Count;

//    while (top.Any())
//    {
//        var amount = top.Count >= 20 ? 20 : top.Count;
//        var selected = top.Take(amount).Select(x => x.User.Name).ToArray();
//        top.RemoveRange(0, amount);

//        foreach (var name in selected)
//        {
//            var channel = await chat.JoinChannelAsync(name);
//            Console.Title = $"Joined {channel} ({chat.Channels.Count} joined / {top.Count} remaining / {total} requested)";
//        }

//        await Task.Delay(TimeSpan.FromSeconds(10));
//    }
//}

//void OnTimer(object? state)
//{
//    Console.WriteLine($"Incoming Message Rate: {msgTotal}/s");
//    msgTotal = 0;
//}

//Task OnMessageAsync(ChatMessage msg)
//{
//    msgTotal++;

//    //Console.WriteLine($"#{msg.Channel.Name.PadRight(10)[..10]}\t{msg.Author?.DisplayName.PadRight(10)[..10]}\t{msg}");

//    return Task.CompletedTask;
//}