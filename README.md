[![Discord](https://discordapp.com/api/guilds/257698577894080512/widget.png)](https://discord.gg/yd8x2wM) ![GitHub Workflow Status](https://img.shields.io/github/workflow/status/AuxLabs/SimpleTwitch/Unit%20Testing?logo=github) ![Nuget](https://img.shields.io/nuget/v/AuxLabs.SimpleTwitch?logo=nuget) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/AuxLabs.SimpleTwitch?logo=nuget)

# SimpleTwitch

Being a base level implementation of the Twitch APIs, this library will be more verbose and unweildy to use for basic apps such as bots or quick scripts. This library is more intended to be the absolute minimum work required to use each API, to be much easier for anyone to take and extend for their specific use cases. For a more complete and user-friendly implementation try [AuxLabs.Twitch](https://github.com/AuxLabs/Twitch), which is a library built on top of this one.

### Builds

Development builds are not yet available.

### Samples

##### Rest
An example of authenticating with the client and requesting a user by name
```csharp
var twitch = new TwitchRestApiClient()
{
    Authorization = new AuthenticationHeaderValue("Bearer", "oauth token")
};

var user = await twitch.GetUsersAsync(new GetUsersParams
{
    UserNames = new[] { "auxlabs" }
});

var user = response.Data.FirstOrDefault();
Console.WriteLine($"{user.DisplayName} is a {user.BroadcasterType}, their account was created on {user.CreatedAt}.");
```

##### Chat
Not yet implemented

##### PubSub
Not yet implemented
