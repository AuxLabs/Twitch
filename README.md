[![Discord](https://discordapp.com/api/guilds/257698577894080512/widget.png)](https://discord.gg/yd8x2wM) 
[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/AuxLabs/SimpleTwitch/main.yml?logo=github)](https://github.com/AuxLabs/SimpleTwitch/actions/workflows/main.yml)
[![Nuget](https://img.shields.io/nuget/v/AuxLabs.SimpleTwitch?logo=nuget)]()

# SimpleTwitch

SimpleTwitch is a bare minimum implmentation of the Twitch APIs. It's built in a way that should make it easy to extend and implement your own clients as needed, if needed. An example of such an implementation is [AuxLabs.Twitch](https://github.com/AuxLabs/Twitch), the main and intended version of the library for general usage.

![Alt](https://repobeats.axiom.co/api/embed/acf35d86a762b5cebeda64f3907597676d78a84c.svg "Repobeats analytics image")

### Builds

Release builds will be available through Nuget, and development builds are available publicly through [Github Packages](https://github.com/orgs/AuxLabs/packages?repo_name=SimpleTwitch).

### Documentation

The API reference, starter tutorials, and other documentation will be available at [the documentation site](https://docs.auxlabs.org/SimpleTwitch/).

### Samples

For examples and sample projects look at [the examples repository](https://github.com/AuxLabs/SimpleTwitch-Examples).

### Features
<details>
  <summary>Rest</summary>
    
- [x] Global ratelimit handling
- [ ] Unique endpoint ratelimit handling
- [x] Check arguments for validity before requests
- [x] Scope confirmation before requests
- [ ] Automatic token refresh
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
  - [ ] 6/19 Moderation
  - [x] 3/3 Polls
  - [x] 3/3 Predictions
  - [ ] 0/2 Raids
  - [ ] 0/6 Schedule
  - [ ] 0/2 Search
  - [ ] 0/3 Music
  - [x] 5/5 Streams
  - [x] 2/2 Subscriptions
  - [x] 2/2 Teams
  - [x] 9/9 Users
  - [x] 2/2 Videos
  - [x] 1/1 Whispers
</details>

<details>
  <summary>Chat</summary>

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
  <summary>EventSub</summary>

- [x] Subscribe/Unsubscribe/View subscriptions through Rest client
- [ ] Ratelimits and Subscription Costs
- [x] WebSocket client
- [ ] WebHook client
- [ ] Automatic heartbeat
- [x] Automatic reconnection
- [ ] Handle all available events
  - [ ] Followers
  - [ ] Subscriptions
  - [ ] Bits Cheered
  - [ ] Raids
  - [ ] User Banned
  - [ ] User Unbanned
  - [ ] Moderators
  - [ ] Rewards
  - [ ] Redemptions
  - [ ] Polls
  - [ ] Predictions
  - [ ] Charity Donations
  - [ ] Charity Campaigns
  - [ ] Drops Entitlements
  - [ ] Extension Bits Transactions
  - [ ] Goals
  - [ ] Hype Trains
  - [ ] Shield Mode
  - [ ] Shoutouts
  - [ ] Stream Status
  - [ ] Authorization Granted/Revoked
  - [ ] User Updated
    
    
</details>

<details>
  <summary>PubSub</summary>

- [ ] Ratelimits
- [ ] Automatic heartbeat
- [ ] Automatic reconnection
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
