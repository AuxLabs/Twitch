[![Discord](https://discordapp.com/api/guilds/257698577894080512/widget.png)](https://discord.gg/yd8x2wM) 
[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/AuxLabs/SimpleTwitch/main.yml?logo=github)](https://github.com/AuxLabs/SimpleTwitch/actions/workflows/main.yml)
[![Nuget](https://img.shields.io/nuget/v/AuxLabs.SimpleTwitch?logo=nuget)]()

# SimpleTwitch

Being a base level implementation of the Twitch APIs, this library will be more verbose and unweildy to use for basic apps such as bots or quick scripts. This library is more intended to be the absolute minimum work required to use each API, to be much easier for anyone to take and extend for their specific use cases. For a more complete and user-friendly implementation try [AuxLabs.Twitch](https://github.com/AuxLabs/Twitch), which is a library built on top of this one.

![Alt](https://repobeats.axiom.co/api/embed/acf35d86a762b5cebeda64f3907597676d78a84c.svg "Repobeats analytics image")

### Builds

Development builds are available publicly through [Github Packages](https://github.com/orgs/AuxLabs/packages?repo_name=SimpleTwitch).

### Documentation

The API reference, starter tutorials, and other documentation will be available at [the documentation site](https://auxlabs.org/SimpleTwitch/).

### Samples

For more examples look at [this repository](https://github.com/AuxLabs/SimpleTwitch-Examples).

##### Rest
An example of authenticating with the client and requesting the current authorized user.
```csharp
string username = "auxlabs";
string token = "token";
string clientId = "client id";
var twitch = new TwitchRestApiClient()
{
    Authorization = new AuthenticationHeaderValue("Bearer", token),
    ClientId = clientId
};

var response = await twitch.GetUsersAsync(args =>
{
    args.UserIds.Add(username);
});

var response = response.Data.FirstOrDefault();
if (response.Data.FirstOrDefault() is User user)
    Console.WriteLine($"{user.DisplayName}'s user id is {user.Id}");
else
    Console.WriteLine($"The user {username} did not exist");
```

##### Chat
An example of authenticating with the client and joining the authorized user's channel
```csharp
string username = "auxlabs";
string token = "token";
var twitch = new TwitchChatApiClient()
twitch.SetIdentity(username, token);

twitch.Connected += () => 
{
    twitch.Send(new JoinChannelRequest(username));
}
twitch.MessageReceived += (args) =>
{
    Console.WriteLine($"#{args.ChannelName} {args.Tags.Login}: {args.Message}");
}

await twitch.RunAsync();
```

##### PubSub
Not yet implemented

##### EventSub
Not yet implemented
