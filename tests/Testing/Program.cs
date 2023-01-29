
//using AuxLabs.SimpleTwitch.Rest;
//using System.Net.Http.Headers;

//var twitch = new TwitchRestApiClient()
//{
//    Authorization = new AuthenticationHeaderValue("Bearer", "4t50mxwfdyq1mbn2qppa0kpbz6k4uz"),
//    ClientId = "6dc9bgiyc1i7o1h03a7q6u7bu3mz9u"
//};

//var identity = await twitch.ValidateAsync();
//var response = await twitch.GetUsersAsync(x =>
//{
//    x.UserIds = new[] { identity.UserId };
//});

//var user = response.Data.FirstOrDefault();
//Console.WriteLine($"{user?.DisplayName} is a {user?.BroadcasterType}, their account was created on {user?.CreatedAt}.");

using AuxLabs.SimpleTwitch.Chat;

var twitch = new TwitchChatApiClient(new TwitchChatConfig
{
    ThrowOnUnknownEvent = true
});
twitch.SetIdentity("auxlabs", "4t50mxwfdyq1mbn2qppa0kpbz6k4uz");

twitch.Connected += OnConnectedAsync;
twitch.PayloadSent += OnPayloadSent;
twitch.PayloadReceived += OnPayloadReceived;

twitch.MessageReceived += OnMessageReceived;
twitch.UserNoticeReceived += OnUserNoticeReceived;

await twitch.RunAsync();

void OnConnectedAsync()
{
    Console.WriteLine("Connected");
    twitch.Send(new JoinChannelRequest("vincewuff"));
}

void OnPayloadSent(IrcPayload msg, int size)
{
    Console.WriteLine("-> " + msg.ToString());
}

void OnPayloadReceived(IrcPayload msg, long size)
{
    var ignoreEvents = new[] { IrcCommand.Message, IrcCommand.GlobalUserState, IrcCommand.UserNotice };
    if (ignoreEvents.Any(x => x == msg.Command)) return;

    Console.WriteLine("<- " + msg.ToString());
}

void OnMessageReceived(MessageEventArgs args)
{
    var name = !string.IsNullOrEmpty(args.Tags.DisplayName) ? args.Tags.DisplayName : args.Tags.Login;

    if (!string.IsNullOrWhiteSpace(args.Tags.ReplyParentMessageId))
        Console.WriteLine($"#{args.ChannelName} {name} -> {args.Tags.ReplyParentUserLogin}: {args.Message}");
    else
        Console.WriteLine($"#{args.ChannelName} {name}: {args.Message}");
}

void OnUserNoticeReceived(UserNoticeEventArgs args)
{
    var name = !string.IsNullOrEmpty(args.Tags.DisplayName) ? args.Tags.DisplayName : args.Tags.Login;
    switch (args.Tags)
    {
        case RaidTags tags:
            Console.WriteLine($"#{args.ChannelName} just got raided by {tags.RaiderDisplayName} with {tags.RaiderViewerCount} viewers!");
            break;
        case SubscriptionGiftTags tags:
            Console.WriteLine($"#{args.ChannelName} {name} just gifted {tags.RecipientDisplayName} a sub!");
            break;
        case SubscriptionTags tags:
            if (tags.NoticeType == UserNoticeType.Subscription)
                Console.WriteLine($"#{args.ChannelName} {name} just subscribed for {tags.TotalMonths} months: {args.Message}");
            else
                Console.WriteLine($"#{args.ChannelName} {name} just resubscribed for {tags.TotalMonths} months: {args.Message}");
            break;
        default:
            if (args.Tags.NoticeType == UserNoticeType.Announcement)
                Console.WriteLine($"#{args.ChannelName} {name} ANNOUNCES: {args.Message}");
            break;
    }
}
