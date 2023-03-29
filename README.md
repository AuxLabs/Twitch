[![Discord](https://discordapp.com/api/guilds/257698577894080512/widget.png "Discord Support Server")](https://discord.gg/yd8x2wM) 
[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/AuxLabs/Twitch/main.yml?logo=github "CI Status")](https://github.com/AuxLabs/Twitch/actions/workflows/main.yml)
[![Nuget](https://img.shields.io/nuget/v/AuxLabs.Twitch?logo=nuget)](https://www.nuget.org/packages/AuxLabs.Twitch/ "Nuget Release Version") [![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/AuxLabs.Twitch?logo=nuget "Nuget Prerelease Version")](https://www.nuget.org/packages/AuxLabs.Twitch/)

# Twitch

Twitch is an implementation of the [Twitch Developer API](https://dev.twitch.tv/) that aims to reformat the data provided by these APIs into a more standardized structure where possible, present itself in a way that isn't overly complicated for a beginner to understand, and cover compatibility for modern platforms. Currently, only the base-level implementation is available via the `*.Api` libraries.

![Alt](https://repobeats.axiom.co/api/embed/acf35d86a762b5cebeda64f3907597676d78a84c.svg "Repobeats analytics image")

### Builds

Release builds will be available through [Nuget](https://www.nuget.org/packages/AuxLabs.Twitch/), and development builds are available publicly through [Github Packages](https://github.com/orgs/AuxLabs/packages?repo_name=Twitch).

### Documentation

The API reference, starter tutorials, and other documentation will be available at [the documentation site](https://docs.auxlabs.org/Twitch/).

### Samples

For examples and sample projects look at [the examples repository](https://github.com/AuxLabs/Twitch-Examples).

### Features
<details>
  <summary>Rest Implementation</summary>
- [x] Global ratelimit handling
- [ ] Unique endpoint ratelimit handling
- [x] Check arguments for validity before requests
- [x] Scope confirmation before requests
- [x] Ability to implement a custom ratelimiter
- [x] Ability to specify a custom rest api url
- [ ] All endpoint categories progress
  - [x] 5/5 Identity
  - [x] 1/1 Ads
  - [x] 2/2 Analytics
  - [x] 3/3 Bits
  - [x] 3/3 Channels
  - [x] 6/6 Channel Points
  - [x] 2/2 Charity
  - [x] 12/12 Chat
  - [x] 2/2 Clips
  - [x] 4/4 Entitlements
  - [ ] 0/12 Extensions
  - [x] 3/3 EventSub
  - [x] 2/2 Games
  - [x] 1/1 Goals
  - [x] 1/1 Hype Trains
  - [x] 19/19 Moderation
  - [x] 3/3 Polls
  - [x] 3/3 Predictions
  - [x] 2/2 Raids
  - [x] 6/6 Schedule
  - [x] 2/2 Search
  - [x] 3/3 Music
  - [x] 5/5 Streams
  - [x] 2/2 Subscriptions
  - [x] 2/2 Teams
  - [x] 9/9 Users
  - [x] 2/2 Videos
  - [x] 1/1 Whispers
</details>

<details>
  <summary>Chat Implementation</summary>
- [ ] Ratelimit handling
- [x] Automatic heartbeat
- [x] Automatic reconnection
- [x] Auto-detect unhandled tags
- [x] Provide a custom irc serializer
- [x] Connect to a custom websocket chat url
- [x] Authenticate anonymously
- [x] Handle all available events
  - [x] Capability Acknowledged
  - [x] Capability Denied
  - [x] Chat Cleared
  - [x] Message Deleted
  - [x] Global User State
  - [x] Notice Received
  - [x] Message Received
  - [x] Room State Received
  - [x] User Notice Received
  - [x] User State Received
  - [x] Whisper Received
  - [x] Channel Joined
  - [x] Channel Left
  - [x] Names Received
</details>

<details>
  <summary>EventSub Implementation</summary>
- [x] Subscribe/Unsubscribe/View subscriptions through Rest client
- [ ] Ratelimits and Subscription Costs
- [x] WebSocket client
- [ ] WebHook client
- [x] Automatic heartbeat
- [x] Automatic reconnection
- [x] Handle all available events
  - [x] Followers
  - [x] Subscriptions
  - [x] Bits Cheered
  - [x] Raids
  - [x] User Banned
  - [x] User Unbanned
  - [x] Moderators
  - [x] Rewards
  - [x] Redemptions
  - [x] Polls
  - [x] Predictions
  - [x] Charity Donations
  - [x] Charity Campaigns
  - [x] Drops Entitlements
  - [x] Extension Bits Transactions
  - [x] Goals
  - [x] Hype Trains
  - [x] Shield Mode
  - [x] Shoutouts
  - [x] Stream Status
  - [x] Authorization Granted/Revoked
  - [x] User Updated
</details>

<details>
  <summary>PubSub Implementation</summary>
- [ ] Ratelimits
- [x] Automatic heartbeat
- [x] Automatic reconnection
- [ ] Handle all available events
  - [ ] Bits
  - [ ] Bist Badge Unlocks
  - [ ] Channel Point Redemptions
  - [ ] Channel Subscriptions
  - [ ] Automod Queue
  - [ ] Moderator Actions
  - [ ] Low Trust User Status
  - [ ] Mdoerator Notifications
  - [ ] Whispers
</details>
